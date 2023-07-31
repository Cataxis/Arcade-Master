using UnityEngine;

public class GeneralGlobal : MonoBehaviour
{
    #region Singleton
    public static GeneralGlobal Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    #endregion

    public GeneralInputController InputController { get; private set;}

    private void OnEnable()
    {
        InputController = GetComponentInChildren<GeneralInputController>();        
    }

}
