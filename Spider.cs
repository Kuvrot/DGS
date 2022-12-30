using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        Vector3 direction = Random.insideUnitCircle.normalized;
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0) , direction , out hit))
        {
            transform.position = hit.point;
            transform.rotation = Quaternion.LookRotation(hit.normal);
            Debug.Log(hit.transform.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
