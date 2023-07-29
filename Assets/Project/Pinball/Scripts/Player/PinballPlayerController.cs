using UnityEngine;

public class PinballPlayerController : MonoBehaviour
{
    [SerializeField] private PinballHandle[] handles;

    private PinballInputController input;

    private void Start()
    {
        input = PinballGameManager.Instance.InputController;
    }

    private void Update()
    {
        MoveHandles();
    }

    private void MoveHandles()
    {
        if (input.Fire())
        {
            foreach (PinballHandle handle in handles) handle.Activate();
        }
        else
        {
            foreach (PinballHandle handle in handles) handle.Deactivate();
        }
    }
}
