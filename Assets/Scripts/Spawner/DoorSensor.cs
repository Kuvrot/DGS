using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{

    public Transform door;
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            door.position = Vector3.Lerp( door.position , new Vector3 (door.position.x , door.position.y , door.position.z  + 2.5f), 10 * Time.deltaTime);
        }
        else
        {
            door.position = Vector3.Lerp(new Vector3(door.position.x, door.position.y, door.position.z + 2.5f) , door.position , 10 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            open = false;
        }
    }
}
