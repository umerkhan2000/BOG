using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public float moveSpeedLimit;
    Vector2 direction = Vector2.zero;
    Vector2 directionForEnemyHit;
    [SerializeField] Rigidbody2D rb;
    float knockBackValue;
    string WeaponType;

    float explsionForce;
    float explsionRadius;
    float upwordDisplace;
    public void SetDirection(Vector2 dir, float bulletspeed, float knockBackValue, string WeaponType, float explsionForce,float explsionRadius,  float upwordDisplace)
    {
        rb.velocity = dir * bulletspeed;
        this.knockBackValue = knockBackValue;
        this.WeaponType = WeaponType;
        this.explsionForce= explsionForce;
          this.explsionRadius= explsionRadius;
           this.upwordDisplace= upwordDisplace;
        directionForEnemyHit = dir;
    }
    private void Update()
    {


    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (WeaponType != "Gun")
        {
            Debug.Log("gernade");
            AddExplosionForce(this.GetComponent<Rigidbody2D>(), explsionForce, this.gameObject.transform.position, explsionRadius, upwordDisplace);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if(WeaponType== "Gun")
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(directionForEnemyHit * knockBackValue, ForceMode2D.Impulse);
            }
          
        }
    }
  public void AddExplosionForce(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }
       GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject obj in Players)
        {
            if (Vector3.Distance(obj.gameObject.transform.position, this.transform.position) < explosionRadius)
            {
                obj.GetComponent<Rigidbody2D>().AddForce(Mathf.Lerp(0, explosionForce, (1 - explosionDistance)) * explosionDir, mode);
                Debug.Log(obj);
            }
        }
      
    }

}

