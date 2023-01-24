using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackGenerater : MonoBehaviour
{
   
   public  WeaponManager weaponManager;   

    [SerializeField] float bulletLifeTime = 3f;
    float nextFire = 0.0f;
    private void Start()
    {

        Debug.Log(weaponManager.weaponName);
    }
    internal void Fire(Vector2 direction, Vector2 playerDir)
    {
      gameObject.name= gameObject.name + "   "+ weaponManager.weaponName;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + weaponManager.fireRate;
            if (direction == Vector2.zero)
            {
                direction = playerDir;
            }

            Vector2 spawnPosition = new Vector2(transform.position.x + (direction.x * 1.1f), transform.position.y + (direction.y * 1.1f));
            //GameObject bullet=  PhotonNetwork.Instantiate("Bullet", transform.position, Quaternion.identity);
            GameObject bullet = PhotonNetwork.Instantiate("Bullet", spawnPosition, Quaternion.identity);
            bullet.GetComponent<Projectile>().SetDirection(direction,weaponManager.bulletSpeed);
            Destroy(bullet, bulletLifeTime);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Weapon")
        {
            weaponManager= collision.gameObject.GetComponent<Weapon>().manager;
            Destroy(collision.gameObject);
        }
    }
}
