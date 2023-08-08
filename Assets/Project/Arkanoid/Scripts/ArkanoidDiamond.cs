using UnityEngine;
using DG.Tweening;

public class ArkanoidDiamond : MonoBehaviour, IDamagable
{
    private int collisionCount;
    [SerializeField] int collisionTarget;
    private SpriteRenderer spriteRenderer;
    private Color initialColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            initialColor = spriteRenderer.color;
        }
    }

    public void Damage()
    {
        collisionCount++;

        if (collisionCount >= collisionTarget)
        {
            DestroyAnimation();
        }
        else
        {
            float alpha = Mathf.Lerp(initialColor.a, 0f, (float)collisionCount / collisionTarget);
            Color newColor = spriteRenderer.color;
            newColor.a = alpha;
            spriteRenderer.color = newColor;
        }
    }

    private void DestroyAnimation()
    {
        ArkanoidGameManager.Instance.BlockDestroyed();
        float duration = 0.5f;
        AnimationCurve crushCurve = new AnimationCurve(
            new Keyframe(0, 0),
            new Keyframe(0.7f, 1.2f),
            new Keyframe(1, 1)
        );

        transform.DOScale(Vector3.zero, duration).SetEase(crushCurve)
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });

        float fadeOutDuration = duration * 0.8f; 
        spriteRenderer.DOFade(0f, fadeOutDuration);
    }
}
