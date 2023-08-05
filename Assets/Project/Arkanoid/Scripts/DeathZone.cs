using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Collider2D))]

public class DeathZone : MonoBehaviour, IDamagable
{
    private Collider2D zoneCollider;



    void OnDrawGizmos()
    {
        if (zoneCollider == null) zoneCollider = GetComponent<Collider2D>();

        Gizmos.color = Color.red;
        Gizmos.DrawCube(zoneCollider.bounds.center, zoneCollider.bounds.size);
    }

    public void Damage()
    {
        ArkanoidGameManager.Instance.Loose();
    }
}
