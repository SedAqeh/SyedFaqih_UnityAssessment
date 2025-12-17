using UnityEngine;
using UnityEngine.InputSystem;

public class SpinnerInput : MonoBehaviour
{
    public Camera cam;
    public SpinnerController spinner;

    public InputActionReference pointerPos;
    public InputActionReference pointerPress;

    public float torqueScale = 0.00015f;

    Vector2 lastPointerPos;
    Vector3 hitPoint;
    bool dragging;

    void OnEnable()
    {
        pointerPos.action.Enable();
        pointerPress.action.Enable();

        pointerPress.action.started += OnPressStarted;
        pointerPress.action.canceled += OnPressCanceled;
    }

    void OnDisable()
    {
        pointerPress.action.started -= OnPressStarted;
        pointerPress.action.canceled -= OnPressCanceled;

        pointerPos.action.Disable();
        pointerPress.action.Disable();
    }

    void OnPressStarted(InputAction.CallbackContext ctx)
    {
        Vector2 screenPos = pointerPos.action.ReadValue<Vector2>();

        if (TryHitSpinner(screenPos, out hitPoint))
        {
            dragging = true;
            lastPointerPos = screenPos;
        }
    }

    void OnPressCanceled(InputAction.CallbackContext ctx)
    {
        dragging = false;
    }

    void Update()
    {
        if (!dragging) return;

        Vector2 currentPos = pointerPos.action.ReadValue<Vector2>();
        Vector2 delta = currentPos - lastPointerPos;

        if (delta.sqrMagnitude > 0.01f)
        {
            ApplyContinuousTorque(delta, hitPoint);
        }

        lastPointerPos = currentPos;
    }

    bool TryHitSpinner(Vector2 screenPos, out Vector3 hit)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit rh) &&
            rh.collider.CompareTag("Spinner"))
        {
            hit = rh.point;
            return true;
        }

        hit = default;
        return false;
    }

    void ApplyContinuousTorque(Vector2 pointerDelta, Vector3 hit)
    {
        Vector3 center = spinner.transform.position;
        Vector3 r = hit - center;

        // Pointer delta → world-ish force
        Vector3 force = new Vector3(pointerDelta.x, 0f, pointerDelta.y);

        float torque = Vector3.Cross(r, force).y;
        spinner.ApplyAngularImpulse(torque * torqueScale);
    }
}
