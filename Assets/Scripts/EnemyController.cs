using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [Header("States")]
    public bool isShooting;
    public AudioClip shootSFX;

    //public float speedMovment = 2.5f;
    Transform target;

    //Components
    NavMeshAgent _nva;
    EnemyStats _enemyStats;
    Canon _canon;
    ParticleSystem _muzzleFlash;
    AudioSource _asrce;

    // Start is called before the first frame update
    void Start() { 
          
        _nva = GetComponent<NavMeshAgent>();
        _enemyStats = GetComponent<EnemyStats>();
         float ranShootRange = Random.Range(5, 20);
        _enemyStats.shootDistance = ranShootRange;
        _canon = GetComponentInChildren<Canon>();
        _muzzleFlash = _canon.GetComponentInChildren<ParticleSystem>();
        target = GameManager.player.transform;
        _nva.stoppingDistance = _enemyStats.shootDistance;
        _nva.speed = Random.Range(1 , 2.5f);
        _asrce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance (transform.position , target.position);

        


        if (distance <= _nva.stoppingDistance)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }


        if (isShooting)
        {
            Shooting();
        }
        else
        {
            Moving();
        }

    }


    void Shooting()
    {
        _nva.isStopped = true;
        FaceTarget();
        StartCoroutine(ShootTimer());
    }


    void Moving()
    {
        _nva.isStopped = false;
        _nva.SetDestination(target.position);

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 lookDir = Vector3.Slerp (transform.localEulerAngles , direction , 10 * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(direction);

    }

    IEnumerator ShootTimer()
    {
        float randomNum = Random.Range(1.5f , 5f);
        yield return new WaitForSeconds(randomNum);
        _asrce.PlayOneShot(shootSFX);
        GameObject bullet = Instantiate(GameManager.bullet, _canon.transform.position, Quaternion.identity);
        BulletScript bs = bullet.GetComponent<BulletScript>();
        bs.destination = target.position + new Vector3 (0f, 1.3f ,0f);
        bs.damage = _enemyStats.damage;
        _muzzleFlash.Play();
        StopAllCoroutines();
        

    }

}
