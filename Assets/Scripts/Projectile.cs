using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public float moveSpeedLimit;
    Vector2 direction = Vector2.zero;
    [SerializeField] Rigidbody2D rb;

    //private void Awake()
    //{
    //    rb.GetComponent<Rigidbody2D>();
    //}

    public void SetDirection(Vector2 dir)
    {
        rb.velocity = dir * moveSpeed;
    }
    private void Update()
    {

        //if (rb.velocity.SqrMagnitude() >= moveSpeedLimit )
        //{
        //    //rb.velocity = new Vector2(Vector2.ClampMagnitude(rb.velocity, moveSpeedLimit).x, rb.velocity.y);
        //    rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeedLimit);
        //}
        //rb.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
    }
}
