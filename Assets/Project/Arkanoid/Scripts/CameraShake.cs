using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Shake Settings")]
    public float shakeDuration = 0.5f;  
    public float shakeMagnitude = 0.1f;  

    private Vector3 originalPosition; 
    private bool isShaking = false;   

    public void Shake()
    {
        if (!isShaking)
        {
            originalPosition = Camera.main.transform.localPosition;
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        isShaking = true;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomShake = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            Camera.main.transform.localPosition = randomShake;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPosition;
        isShaking = false;
    }
}
