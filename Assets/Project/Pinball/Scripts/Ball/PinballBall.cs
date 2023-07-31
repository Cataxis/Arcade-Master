using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBall : MonoBehaviour
{
    public Rigidbody2D Body2D { get; private set;}

    private void Awake()
    {
        Body2D = GetComponent<Rigidbody2D>();
    }
}
