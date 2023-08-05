using UnityEngine;

public class ArkanoidBall : MonoBehaviour
{
    [Header("Movement Player")]
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float speedMultiplier;

    [Header("Collision")]
    [SerializeField] private float radius;

    private Rigidbody2D body;

    private bool isActive = false;
    private float currentSpeed = 0f;

    private Vector2 direction = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    ContactPoint2D[] contactPoints = new ContactPoint2D[1];

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = defaultSpeed;
    }
    private void FixedUpdate()
    {
        CalculateCollision();
        Move();
    }

    public void Activate()
    {
        body.isKinematic = false;
        transform.SetParent(null);
        isActive = true;
        direction = new Vector2(transform.position.x, 1f).normalized;
    }
    public void Deactivate()
    {
        isActive = false;
    }

    private void Move()
    {
        if (!isActive) return;
        velocity = direction * (currentSpeed * Time.fixedDeltaTime);
        body.position += velocity;
    }
    private void CalculateCollision()
    {     
        int contacts = body.GetContacts(contactPoints);
        if (contacts == 0) return;

        if (contactPoints[0].collider.TryGetComponent(out IDamagable _damagable))
        {
            if (_damagable is ArkanoidBlock) currentSpeed *= speedMultiplier;
            _damagable.Damage();
        }

        Vector2 targetDirection = direction - (Vector2.Dot(direction, contactPoints[0].normal) * 2f) * contactPoints[0].normal;
        Debug.DrawLine(contactPoints[0].point, contactPoints[0].point + targetDirection, Color.red, 2f);
        direction = targetDirection.normalized;
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
