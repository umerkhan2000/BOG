using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    protected Rigidbody2D rb;
    
    public float moveSpeed;
    public float moveMaxSpeed;
    [Space]
    public float jumpPower;
    //public float jumpMaxSpeed;
    public int totalJumps;
    int currentJumps;
    internal Vector2 direction;
    bool canJump;
    PhotonView photonView;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        photonView =GetComponent<PhotonView>();
    }
    private void Start()
    {
        canJump = true;
        currentJumps= totalJumps;
    }
    private void FixedUpdate()
    {
        Movevement();

        
    }
    private void Update()
    {
        if (rb.velocity.SqrMagnitude() >= moveMaxSpeed)
        {
            rb.velocity = new Vector2(Vector2.ClampMagnitude(rb.velocity, moveMaxSpeed).x,rb.velocity.y);
        }  
        //if (rb.velocity.y >= jumpMaxSpeed)
        //{

        //    rb.velocity = new Vector2(rb.velocity.x, Vector2.ClampMagnitude(rb.velocity, jumpMaxSpeed).y);
        //}

        //Debug.Log(rb.velocity.magnitude); 
    }

    private void Movevement()
    {
        if (direction==Vector2.zero || !photonView.IsMine)
        {
            return;
        }
        rb.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
    }
    public void Jump()
    {
        if ( currentJumps<=0 || !photonView.IsMine)
        {
            return;
        }
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        currentJumps -= 1;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Land"))
        {
            canJump = true;
            currentJumps = totalJumps;
        }
        
    }
    internal void SetMoveDirection(Vector2 direction)=>this.direction= direction;
    
}
