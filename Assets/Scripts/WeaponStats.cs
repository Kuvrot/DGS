using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{

    public int ID;
    public bool isAutomatic;
    public float fireRate = 2f;
    public float reloadTime = 2f;
    public float Damage;
    public int maxBulletsPerMagazine;
    public int curBulletsMagazine;
    public int totalBullets;
    public Canon canon;
    

    // Start is called before the first frame update
    void Start()
    {
        canon = GetComponentInChildren<Canon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curBulletsMagazine <= 0)
        {
            curBulletsMagazine = 0;
        }
    }

   

}
