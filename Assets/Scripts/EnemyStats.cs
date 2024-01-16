using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 100;
    public float damage = 12;
    public float shootDistance;
    public float fireRate = 2f;

    SpawnManager sm;

    public bool isDeath;

    // Start is called before the first frame update
    void Start()
    {

        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpawnManager>();
        sm.curEnemies++;
        sm.enemies_list.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            isDeath = true;
        }

        if (isDeath)
        {
            sm.enemies_list.Remove(this.gameObject);
            Instantiate(GameManager.explosionFX , transform.position + new Vector3 (0f,1,0f), transform.rotation);
            Destroy(gameObject);
        }
    }

    public void getDamage(float amount)
    {
        health -= amount;
    }
}
