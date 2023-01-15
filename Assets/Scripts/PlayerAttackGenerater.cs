using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackGenerater : MonoBehaviour
{

internal void Fire(Vector2 direction)
    {
        GameObject bullet=  PhotonNetwork.Instantiate("Bullet", transform.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().SetDirection(direction);

    }

     }
