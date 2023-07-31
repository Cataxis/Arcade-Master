using UnityEngine;
using UnityEngine.Events;

public class PinballBounceEffector : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private UnityEvent onBounce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PinballBall detectedBall))
        {
            Vector2 direction = -collision.GetContact(0).normal;
            Vector2 force = direction * bounceForce;
            detectedBall.Body2D.AddForce(force, ForceMode2D.Impulse);
            onBounce?.Invoke();
        }
    }
}
