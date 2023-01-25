using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerAttackGenerater : MonoBehaviour
{

    public WeaponManager weaponManager;
    public WeaponManager InitialWeaponAlaways;
    public List<GameObject> list = new List<GameObject>();
    [SerializeField] float bulletLifeTime = 3f;
    float nextFire = 0.0f;
    int bulletFired;
    private void Start()
    {

        Debug.Log(weaponManager.weaponName);
    }
    internal void Fire(Vector2 direction, Vector2 playerDir)
    {

        if (weaponManager.bulletCount > bulletFired) 
        { 

            if (Time.time > nextFire)
            {
                bulletFired++;
                nextFire = Time.time + weaponManager.fireRate;
                if (direction == Vector2.zero)
                {
                    direction = playerDir;
                }

                Vector2 spawnPosition = new Vector2(transform.position.x + (direction.x * 1.1f), transform.position.y + (direction.y * 1.1f));
                //GameObject bullet=  PhotonNetwork.Instantiate("Bullet", transform.position, Quaternion.identity);
                if(weaponManager.weaponType== "Gun")
                {
                    GameObject bullet = PhotonNetwork.Instantiate("Bullet", spawnPosition, Quaternion.identity);
                    bullet.GetComponent<Projectile>().SetDirection(direction, weaponManager.bulletSpeed, weaponManager.knockBackValue, weaponManager.weaponType, weaponManager.explosionForce, weaponManager.explosionRadius, weaponManager.upwordDisplace);
                    Destroy(bullet, bulletLifeTime);
                }
                else
                {
                    GameObject Explosives = PhotonNetwork.Instantiate("Bullet 1", spawnPosition, Quaternion.identity);
                    Explosives.GetComponent<Projectile>().SetDirection(new Vector2(transform.position.x + (direction.x * 1.1f), transform.position.y - (direction.y * 1.1f)), weaponManager.bulletSpeed, weaponManager.knockBackValue, weaponManager.weaponType, weaponManager.explosionForce, weaponManager.explosionRadius, weaponManager.upwordDisplace);
                    Destroy(Explosives, bulletLifeTime);
                }
               

            }
            

    }
        else
        {
            if(weaponManager.weaponName == "Pistol")
            {
                weaponManager.bulletCount = 10;
                bulletFired= 0;
            }
            else
            {
                
               Debug.Log("out of bullets");
                weaponManager = InitialWeaponAlaways;
                GameObject weaponObj = Instantiate(InitialWeaponAlaways.weaponPrefab, gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
                weaponObj.transform.parent = this.gameObject.transform;
                list.Add(weaponObj);
                Destroy(list[0].gameObject);
                list.RemoveAt(0);
               


            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Weapon")
        {
            weaponManager= collision.gameObject.GetComponent<Weapon>().manager;
            Destroy(collision.gameObject);
            GameObject weaponObj= Instantiate(weaponManager.weaponPrefab, gameObject.transform.GetChild(0).transform.position,Quaternion.identity) ;
            bulletFired = 0;
            list.Add(weaponObj);
           
            weaponObj.transform.parent= this.gameObject.transform;
            if (gameObject.transform.childCount > 2)
            {
                Debug.Log(gameObject.transform.childCount);
                Destroy(list[0].gameObject);
                list.RemoveAt(0);
            }
        }
    }
}
