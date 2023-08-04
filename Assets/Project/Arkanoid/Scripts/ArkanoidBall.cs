using UnityEngine;

public class ArkanoidBall : MonoBehaviour
{
    [Header("Movement Player")]
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float speedMultiplier;

    [Header("Collision")]
    [SerializeField] private float radius;

    private Transform targetTransform;

    private bool isActive = false;
    private bool alreadyCollided = false;
    private float currentSpeed = 0f;

    private Vector2 direction = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    private Collider2D lastCollisionCol;

    private void Awake()
    {
        targetTransform = transform;
        currentSpeed = defaultSpeed;
    }
    private void Update()
    {
        CalculateCollision();
        Move();
    }

    public void Activate()
    {
        targetTransform.SetParent(null);
        isActive = true;
        direction = new Vector2(targetTransform.position.x, 1f).normalized;
    }
    public void Deactivate()
    {
        isActive = false;
    }

    private void Move()
    {
        if (!isActive) return;
        velocity = direction * (currentSpeed * Time.deltaTime);
        targetTransform.position += (Vector3)velocity;
    }
    private void CalculateCollision()
    {
        if (!isActive) return;
        RaycastHit2D hit = Physics2D.CircleCast(targetTransform.position, radius, direction,velocity.magnitude);
        if (hit.collider == null)
        {
            alreadyCollided = false;
            return;
        }

        if (lastCollisionCol != null && hit.collider != lastCollisionCol) alreadyCollided = false;
        

        if (!alreadyCollided)
        {
            alreadyCollided = true;

            lastCollisionCol = hit.collider;
            if (lastCollisionCol.TryGetComponent(out IDamagable _damagable))
            {
                if (_damagable is ArkanoidBlock) currentSpeed *= speedMultiplier;
                _damagable.Damage();
            }

            Vector2 targetDirection = direction - (Vector2.Dot(direction, hit.normal) * 2f) * hit.normal;
              direction = targetDirection.normalized;
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction);
    }
#endif
}
