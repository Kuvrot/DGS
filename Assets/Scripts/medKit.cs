using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class medKit : MonoBehaviour
{

    public int healthAmount = 40;
    public AudioClip sfx;
    bool healed , interact;
    AudioSource asrce;


    // Start is called before the first frame update
    void Start()
    {
        asrce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact && !healed)
        {
            GameManager.playerStats.Health += healthAmount;
            asrce.PlayOneShot(sfx);
            healed = true;
        }

        if (healed)
        {
            if (!asrce.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interact = true;
        }
    }

}
