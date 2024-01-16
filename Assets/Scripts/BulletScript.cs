using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float damage = 0;

    //Direction the bullet will go to 
    public Vector3 destination;

    private Vector3 initialPos , direction;

    public bool stop;

    //Time before the object is destroy
    public float lifeTime = 1;

    //Travel speed
    public float speed = 100;


    // Start is called before the first frame update
    void Start()
    {
       // destination = GameManager.bulletDirection;
        initialPos = transform.position;
        direction = (destination - initialPos).normalized;

    }

    // Update is called once per frame
    void Update()
    {

        if (!stop)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds (lifeTime);
        Destroy(this.gameObject);
        StopAllCoroutines();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.playerStats.GetDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            stop = true;
        }
    }

}
