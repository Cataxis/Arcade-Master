using UnityEngine;


public class ArkanoidPlayer : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float xBounds = 4.5f;
    [SerializeField] private ArkanoidBall initialBall;

    private GeneralInputController input;
    private Transform targetTransform;
    private bool isActive = true;

    private void Awake() => targetTransform = transform;
    private void Start() => input = Global.Instance.InputController;
    void Update()
    {
        TryLaunch();
        Move();
    }

    private void Move()
    {
        if (!isActive) return;
        
        float xMovement = input.GetInputDirection().x;
        Vector2 direction = new Vector2(xMovement, 0f);
        Vector2 finalMovement = direction * (speed * Time.deltaTime);

        Vector2 finalPosition = targetTransform.position;
        finalPosition += finalMovement;
        finalPosition.x = Mathf.Clamp(finalPosition.x, -xBounds, xBounds);

        targetTransform.position = finalPosition;
    }
    private void Activate() => isActive = true;
    private void Deactivate() => isActive = false;

    private void TryLaunch()
    {
        //Change this to a "cannon script"
        if (!input.Fire()) return;

        initialBall?.Activate();
        initialBall = null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine((Vector3.right * xBounds) + Vector3.up * 10f, (Vector3.right * xBounds) + Vector3.up * -10f);
        Gizmos.DrawLine((Vector3.right * -xBounds) + Vector3.up * 10f, (Vector3.right * -xBounds) + Vector3.up * -10f);
    }
#endif
}
