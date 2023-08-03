using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
