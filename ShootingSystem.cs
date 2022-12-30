using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingSystem : MonoBehaviour
{

    public InputAction shoot_input;
    public InputAction reload_input;
    public bool canShoot;
    public bool shooting;
    public bool reload;
    public bool blocking;
    Camera _camera;
    [HideInInspector]
    public Inventory _inventory;
    Animator anim, camAnim;
    AudioSource asrce;
    CameraController camController;
    [HideInInspector]
    public WeaponStats _weaponStats;
    GunSFX gunSFX;

    [Header("SFX")]
    public AudioClip shoot_SFX, reload_SFX;


    // Start is called before the first frame update
    void Start()
    {
        //anim = _inventory.weapons[_inventory.curWeapon].GetComponent<Animator>();
        _camera = Camera.main.GetComponent<Camera>();
        _inventory = GetComponent<Inventory>();
        camController = GetComponent<CameraController>();
        _weaponStats = _inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>();
        asrce = GetComponent<AudioSource>();
        gunSFX = GetComponent<GunSFX>();
        camAnim = GetComponent<Animator>();
        int ranWeapon = Random.Range(0 , _inventory.weapons.Length);
        WeaponSwitch(ranWeapon);
    }

    private void OnEnable()
    {
        shoot_input.Enable ();
        reload_input.Enable ();
    }

    private void OnDisable()
    {
        shoot_input.Disable();
        reload_input.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        

       if (!camController.moving)
        {

            anim.SetBool("sprint", false);
            

            if (!shooting && !blocking)
            {
                if (canShoot && !reload)
                {
                    if (shoot_input.ReadValue<float>() > 0.5f && _weaponStats.curBulletsMagazine > 0)
                    {
                        switch (_weaponStats.ID)
                        {

                            case 0: asrce.PlayOneShot(gunSFX.shotgunSFX);  break;
                            case 1: int n = Random.Range(0, 2); asrce.PlayOneShot(gunSFX.pistolSFX[n]);  break;
                            case 2: asrce.PlayOneShot(gunSFX.rifleSFX); break;
                        }

                        StartCoroutine(waitfornextshoot());
                        
                        
                    }
                   
                }
            }
        }
        else
        {
            anim.SetBool("sprint" , true);
        }

        
    }

    IEnumerator waitfornextshoot ()
    {
        shooting = true;
        canShoot = false;
        Shoot();
        anim.SetTrigger("shoot");
        camAnim.SetTrigger("shoot");
        yield return new WaitForSeconds (_weaponStats.fireRate);
        canShoot = true;
        shooting = false;
        StopAllCoroutines();
    }

    public void WeaponSwitch (int weapon_id)
    {

        foreach (GameObject w in _inventory.weapons)
        {
            w.SetActive(false);
        }


        _inventory.curWeapon = weapon_id;

        _inventory.weapons[_inventory.curWeapon].SetActive(true);

        anim = _inventory.weapons[_inventory.curWeapon].GetComponent<Animator>();
        _weaponStats = _inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>();



    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 100))
        {

            _weaponStats.canon.GetComponentInChildren<ParticleSystem>().Play();

            //Instantiate(GameManager.bullet , _inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>().canon.transform.position , _inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>().canon.transform.rotation);

            // GameManager.bulletDirection = Vector3.zero;

            if (hit.transform.GetComponentInParent<EnemyStats>())
            {
                EnemyStats enemyStats = hit.transform.GetComponentInParent<EnemyStats>();

               if (!hit.transform.GetComponentInParent<Shield>())
                {
                    if (hit.transform.name == "Body")
                    {
                        if (_weaponStats.ID == 0)
                        {
                            float distance = Vector2.Distance(hit.point, transform.position);

                            if (distance <= 3)
                            {
                                enemyStats.getDamage(_inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>().Damage * 2);
                            }
                            else
                            {
                                enemyStats.getDamage(_inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>().Damage);
                            }


                        }
                        

                    }
                    else if (hit.transform.name == "Head")
                    {
                        enemyStats.getDamage(_inventory.weapons[_inventory.curWeapon].GetComponent<WeaponStats>().Damage * 2);
                    }

                   

                    Instantiate(GameManager.bloodHitFX, hit.point, Quaternion.LookRotation(hit.normal));
                }
                else {

                    Instantiate(GameManager.hitFX, hit.point, Quaternion.LookRotation(hit.normal));

                }

            }
            else
            {

                Instantiate(GameManager.hitFX, hit.point, Quaternion.LookRotation(hit.normal));

            }
            //anim.SetBool("idle", false);

           

        }

        _weaponStats.curBulletsMagazine -= 1;


    }
}
