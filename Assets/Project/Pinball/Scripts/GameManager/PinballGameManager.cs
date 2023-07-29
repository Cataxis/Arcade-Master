using UnityEngine;

public class PinballGameManager : MonoBehaviour
{
    #region Singleton
    public static PinballGameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    #endregion

    public PinballInputController InputController { get; private set;}

    private void OnEnable()
    {
        InputController = GetComponentInChildren<PinballInputController>();        
    }

}
