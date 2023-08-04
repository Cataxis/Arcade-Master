using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement Player")]
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier;

    private Rigidbody2D ballRb;

    private GeneralInputController input;

    void Start()
    {
        input = GeneralGlobal.Instance.InputController;
        ballRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(input.Fire())
        {
            Launch();
        }
    }

    private void Launch()
    {
        transform.parent = null;
        ballRb.velocity = initialVelocity;
    }

private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent(out IDamagable damagable))
        {

            //TODO Power Ups

            if (damagable is Block)
            {

                ballRb.velocity *= velocityMultiplier;
            }

            damagable.Damage();

        }

        VelocityFix();
    }


    private void VelocityFix()
    {
        float velocityDelta = 0.5f;
        float minVelocity = 0.2f;

        if (Mathf.Abs(ballRb.velocity.x) < minVelocity)
        {
            velocityDelta = UnityEngine.Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(velocityDelta, 0f);
        }

        if (Mathf.Abs(ballRb.velocity.y) < minVelocity)
        {
            velocityDelta = UnityEngine.Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(0f, velocityDelta);
        }
    }
}
