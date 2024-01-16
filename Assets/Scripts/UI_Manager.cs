using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Slider healthBar;
    public Text ammo;

    //Components
    ShootingSystem shootingSystem;


    // Start is called before the first frame update
    void Start()
    {
        shootingSystem = GetComponent<ShootingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = GameManager.playerStats.Health;

        ammo.text = shootingSystem._weaponStats.curBulletsMagazine.ToString();
        
    }
}
