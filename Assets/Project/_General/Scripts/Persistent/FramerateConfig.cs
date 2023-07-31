using UnityEngine;

public class FramerateConfig : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
