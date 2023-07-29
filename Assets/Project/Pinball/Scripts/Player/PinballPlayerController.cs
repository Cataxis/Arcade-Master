using UnityEngine;

public class PinballPlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private PinballPlayerHandle[] handles;

    private PinballInputController input;

    private void Start()
    {
        input = PinballGameManager.Instance.InputController;
    }

    private void Update()
    {
        Move();
        ActivateHandles();
    }

    private void Move()
    {
        Vector2 inputDirection = input.GetInputDirection().normalized;
        Vector2 movement = inputDirection * (movementSpeed * Time.deltaTime);
        Vector2 finalPosition = (Vector2)transform.position + movement;        
        transform.position  = finalPosition;
    }
    private void ActivateHandles()
    {
        if (input.Fire())
        {
            foreach (PinballPlayerHandle handle in handles) handle.Activate();
        }
        else
        {
            foreach (PinballPlayerHandle handle in handles) handle.Deactivate();
        }
    }
}
