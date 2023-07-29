using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PinballPlayerHandle : MonoBehaviour
{
    [SerializeField] private float rotationDelta;
    [SerializeField] private float activatedRotation;

    private Rigidbody2D body2d;
    private float initialRotation;

    private bool isActive = false;

    private void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        initialRotation = body2d.rotation;
    }
    private void FixedUpdate()
    {
        Rotate();
    }

    public void Activate() => isActive = true;
    public void Deactivate() => isActive = false;
    
    private void Rotate()
    {
        float targetRotation = body2d.rotation;
        if (isActive) targetRotation = activatedRotation;
        else targetRotation = initialRotation;
        body2d.SetRotation(Mathf.MoveTowardsAngle(body2d.rotation, targetRotation, rotationDelta * Time.fixedDeltaTime));
    }

}
