using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestrucableWall : MonoBehaviour, IDamagable
{
    private bool black;
    private Collider2D zoneCollider;
    void OnDrawGizmos()
    {
        if (zoneCollider == null)
        {
            zoneCollider = GetComponent<Collider2D>();
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(zoneCollider.bounds.center, zoneCollider.bounds.size);

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.blue;
        style.fontSize = 8;
        Handles.Label(zoneCollider.bounds.center, "Wall", style);
    }

    public void Damage()
    {

        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (GameManager.Instance.effectsActive == true)
        {
            if (!black)
            {
                ChangeColorsToBlack();
            }
            else
            {
                ChangeColorsToWhite();
            }

            Camera.main.GetComponent<CameraShake>().Shake();

        }
    }

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
        black = false;
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
        black = true;
    }


}
