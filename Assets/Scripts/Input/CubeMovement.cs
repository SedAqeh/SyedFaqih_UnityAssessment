using UnityEngine;
using UnityEngine.InputSystem;

public class CubeMover : MonoBehaviour
{
    public float speed = 5f;
    public InputActionReference moveAction;

    void OnEnable() => moveAction.action.Enable();
    void OnDisable() => moveAction.action.Disable();

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 dir = new Vector3(input.x, 0f, input.y);
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}
