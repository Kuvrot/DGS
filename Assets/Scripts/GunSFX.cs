using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSFX : MonoBehaviour
{

    public AudioClip shotgunSFX;
    public AudioClip rifleSFX;
    public AudioClip[] pistolSFX;

    //Components
    AudioSource asrce;




    // Start is called before the first frame update
    void Start()
    {
        asrce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
