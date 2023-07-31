using UnityEngine;

public class BounceTransformAnimation : MonoBehaviour
{
    private GameObject target;
    private Vector3 initialGraphicsScale;

    private void Awake()
    {
        target = gameObject;
        initialGraphicsScale = target.transform.localScale;
    }
    public void Bounce()
    {
        target.LeanCancel();
        target.transform.localScale = initialGraphicsScale * 1.2f;
        target.LeanScale(initialGraphicsScale, .15f);
    }
}
