using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup_weapon : MonoBehaviour
{

    public int ID;
    public GameObject[] weapons , weaponsUI;
    public InputAction interaction;
    public ShootingSystem shootingSystem;
    public AudioClip pickUpSound;
    AudioSource asrce; 

    bool canInteract , pickedUp;


    private void OnEnable()
    {
        interaction.Enable();
    }

    private void OnDisable()
    {
        interaction.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {

        shootingSystem = GameManager.shootingSystem;

        asrce = GetComponent<AudioSource>();


        foreach (GameObject s in weapons)
        {
            s.SetActive(false);
        }

        foreach (GameObject s in weaponsUI)
        {
            s.SetActive(false);
        }

        int ranID = Random.Range(0 , weapons.Length);
        ID = ranID;
        weapons[ID].SetActive(true);
        weaponsUI[ID].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {


        if (pickedUp)
        {
            if (!asrce.isPlaying)
            {
                Destroy(gameObject);
            }
        }

        if (canInteract && !pickedUp)
        {
            if (interaction.ReadValue<float>() > 0.5f)
            {

                asrce.PlayOneShot(pickUpSound);
                changeWeapon();
                pickedUp = true;
            }
        }
    }

    void changeWeapon()
    {

        if (ID != shootingSystem._inventory.curWeapon)
        {
            foreach (GameObject s in weapons)
            {
                s.SetActive(false);
            }

            foreach (GameObject s in weaponsUI)
            {
                s.SetActive(false);
            }

            weapons[shootingSystem._weaponStats.ID].SetActive(true);
            weaponsUI[shootingSystem._weaponStats.ID].SetActive(true);

            shootingSystem.WeaponSwitch(ID);
            ID = shootingSystem._weaponStats.ID;
        }
        else
        {
            shootingSystem._weaponStats.curBulletsMagazine += 50;
        }

        canInteract = false;
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
        }
    }

}
