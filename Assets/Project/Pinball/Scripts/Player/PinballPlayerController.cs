using UnityEngine;

public class PinballPlayerController : MonoBehaviour
{
    [SerializeField] private PinballPlayerHandle[] handles;

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
            foreach (PinballPlayerHandle handle in handles) handle.Activate();
        }
        else
        {
            foreach (PinballPlayerHandle handle in handles) handle.Deactivate();
        }
    }
}
