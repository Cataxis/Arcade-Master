using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Shake Settings")]
    public float shakeDuration = 0.5f;  
    public float shakeMagnitude = 0.1f;  

    private Vector3 initialPosition; 
    private bool isShaking = false;

    private Camera currentCamera;

    private void Start()
    {
        UpdateCamera();
    }
    private void OnEnable() => Global.Instance.SceneController.OnSceneLoaded += UpdateCamera;
    private void OnDisable() => Global.Instance.SceneController.OnSceneLoaded -= UpdateCamera;     
    private void UpdateCamera()
    {
        currentCamera = null;
        currentCamera = Camera.main;
        if(currentCamera == null) currentCamera = FindObjectOfType<Camera>();

        initialPosition = currentCamera.transform.position;
    }

    public void Shake()
    {
        if (isShaking) return;

        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine());

        IEnumerator ShakeCoroutine()
        {
            isShaking = true;
            float elapsedTime = 0f;

            while (elapsedTime < shakeDuration)
            {
                Vector3 randomShake = initialPosition + Random.insideUnitSphere * shakeMagnitude;
                currentCamera.transform.localPosition = randomShake;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            currentCamera.transform.localPosition = initialPosition;
            isShaking = false;
        }
    }
}
