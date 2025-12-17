using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    public float momentOfInertia = 1f;
    public float damping = 6f;

    float angularVelocity;

    void Update()
    {
        transform.Rotate(Vector3.up, angularVelocity * Mathf.Rad2Deg * Time.deltaTime);
        angularVelocity = Mathf.MoveTowards(
            angularVelocity, 0f, damping * Time.deltaTime
        );
    }

    public void ApplyAngularImpulse(float impulse)
    {
        angularVelocity += impulse / momentOfInertia;
    }

    public float AngularSpeed => angularVelocity;
}
