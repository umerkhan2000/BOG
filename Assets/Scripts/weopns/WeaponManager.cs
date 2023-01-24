using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class WeaponManager : ScriptableObject
{
    public string weaponName;
    public float fireRate;
    public float bulletSpeed;
    public float knockBackValue;
    public GameObject weaponPrefab;
  //  public GameObject[] weaponskin;
}
