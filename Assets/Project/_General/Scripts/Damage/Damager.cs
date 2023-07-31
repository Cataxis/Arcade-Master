using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private Collider2D colliderToCast;

    private void Update()
    {
        SearchForDamagable();
    }
    private void SearchForDamagable()
    {
        ContactFilter2D filter = new ContactFilter2D();
        Collider2D[] results = new Collider2D[5];
        int detectedCols = Physics2D.OverlapCollider(colliderToCast, filter, results);
        if (detectedCols == 0) return;

        for (int i = 0; i < detectedCols; i++)
        {
            if (results[i].TryGetComponent(out IDamagable damagable))
            {
                damagable.Damage();
                return;
            }
        } 
    }
}
