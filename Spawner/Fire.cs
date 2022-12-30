using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public bool damage = false;
    public float interval = 0.5f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (damage)
        {
            timer -= 1 * Time.deltaTime;

            if (timer <= 0)
            {
                GameManager.player.GetComponent<PlayerStats>().GetDamage(50);
                timer = interval;
            }

        }
        else
        {
            timer = interval;
        }

    }


    void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            damage = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            damage = false;
        }
    }
}
