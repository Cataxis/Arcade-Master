using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class Block : MonoBehaviour, IDamagable
{
    private Collider2D zoneCollider;
    void OnDrawGizmos()
    {
        if (zoneCollider == null)
        {
            zoneCollider = GetComponent<Collider2D>();
        }

        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(zoneCollider.bounds.center, zoneCollider.bounds.size);

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.cyan;
        style.fontSize = 6;
        Handles.Label(zoneCollider.bounds.center, "Block", style);
    }

    public void Damage()
    {
        // Resta una unidad a la cantidad de bloques totales en el nivel actual
        GameManager.Instance.BlockDestroyed();

        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Play();
        }

        float duration = 0.5f;

        AnimationCurve crushCurve = new AnimationCurve(
            new Keyframe(0, 0),
            new Keyframe(0.7f, 1.2f),
            new Keyframe(1, 1)
        );

        // Animación de reducción de tamaño
        transform.DOScale(Vector3.zero, duration).SetEase(crushCurve)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });

    }
}
