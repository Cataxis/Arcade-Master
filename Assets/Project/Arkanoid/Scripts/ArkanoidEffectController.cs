using UnityEngine;

public class ArkanoidEffectController : MonoBehaviour
{
    private CameraShake cameraShake;
    private bool isInverted = false;

    private void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
    }

    public void ToggleColors()
    {
        if (isInverted) ChangeColorsToBlack();
        else ChangeColorsToWhite();

        isInverted = !isInverted;
    }
    public void ShakeCamera() => cameraShake?.Shake();
    

    private void ChangeColorsToWhite()
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject go in gameObjects)
        {
            SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.white;
            }
        }

        Camera.main.backgroundColor = Color.black;
    }
    private void ChangeColorsToBlack()
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject go in gameObjects)
        {
            SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.black;
            }
        }

        Camera.main.backgroundColor = Color.white;
    }
}
