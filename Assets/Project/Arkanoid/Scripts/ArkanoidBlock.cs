using UnityEngine;
using DG.Tweening;

public class ArkanoidBlock : MonoBehaviour, IDamagable
{

    public void Damage()
    {      
        ArkanoidGameManager.Instance.BlockDestroyed();
        DestroyAnimation();
    }

    private void DestroyAnimation()
    {
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
