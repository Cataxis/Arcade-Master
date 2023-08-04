using UnityEngine;

public class Global : MonoBehaviour
{
    #region Singleton
    public static Global Instance;
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
    public SceneController SceneController { get; private set;}

    private void OnEnable()
    {
        InputController = GetComponentInChildren<GeneralInputController>();
        SceneController = GetComponentInChildren<SceneController>();        
    }

}
