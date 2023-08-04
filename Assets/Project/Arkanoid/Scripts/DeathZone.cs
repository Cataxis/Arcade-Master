using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]

public class DeathZone : MonoBehaviour, IDamagable
{
    private Collider2D zoneCollider;

    void OnDrawGizmos()
    {
        if (zoneCollider == null)
        {
            zoneCollider = GetComponent<Collider2D>();
        }

        Gizmos.color = Color.red;
        Gizmos.DrawCube(zoneCollider.bounds.center, zoneCollider.bounds.size);

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 14;
        Handles.Label(zoneCollider.bounds.center, "Death Zone", style);
    }

    public void Damage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
