using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] enemies;

    public Transform spawnPoint;

    SpawnManager sm;
    public int wave;
    public bool spawn;

    public int nTimesSpawn; //This tells how many times enemies will spawn

    public float spawnTimer; //Time between spawns
    public int distribution;
    float ran;

   

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpawnManager>();
        if (spawnPoint == null)
        {
            spawnPoint = this.transform;
        }

        spawn = true;

        ran = Random.Range(5.0f, 10.0f);

    }

    // Update is called once per frame
    void Update()
    {



        if (sm.isWaveActive)
        {

            StartCoroutine(timeBetweenSpawns());

            if (!spawn)
                {
                   if (sm.curEnemies + 1 <= sm.enemies)
                   {
                        if (sm.enemies_list.Count <= 12 - 4)
                        {
                      
                            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoint.position, spawnPoint.rotation);
                            spawn = true;
                            StartCoroutine(timeBetweenSpawns());

                        }               
                   }
                }  
        }
    }

    IEnumerator timeBetweenSpawns()
    {
        yield return new WaitForSeconds(ran);
        ran = Random.Range(5.0f, 10.0f);
        spawn = false;
        StopAllCoroutines();
    }

    
}
