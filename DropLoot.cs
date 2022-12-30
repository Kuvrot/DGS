using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{

    public GameObject drop;
    public GameObject medKit;

    // Start is called before the first frame update
    void Start()
    {
        int ran = Random.Range (0 , 100);
        int dropSelector = Random.Range(0, 101);

        //drop if 
        if (ran < 34)
        {
            if (dropSelector >= 50)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(medKit, transform.position, transform.rotation);
            }
        }
    }

}
