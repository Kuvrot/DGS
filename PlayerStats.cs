using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float Health = 100;
    public GameObject bloodImage , deathImage;
    AudioSource asrce;
    public AudioClip hitSFX;

    // Start is called before the first frame update
    void Start()
    {
        asrce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Death();

        }else if (Health >= 100)
        {

            Health = 100;
        }


    }

    public void GetDamage (float amount)
    {
        Health -= amount;
        bloodImage.SetActive(true);
        StartCoroutine(bloodTimer());
    }

    IEnumerator bloodTimer()
    {
        asrce.PlayOneShot(hitSFX);
        yield return new WaitForSeconds(0.15f);
        bloodImage.SetActive(false);
        StopAllCoroutines();
    }

    void Death ()
    {
        deathImage.SetActive(true);
        bloodImage.SetActive(false);
        //bloodImage.GetComponent<Image>().color = Color.red;
        GameManager.playerManager.GetComponent<Animator>().SetTrigger("shoot");
        Time.timeScale = 0.05f;
        //Instantiate(GameManager.explosionFX, transform.position, transform.rotation);
        StartCoroutine(deathTimer());


    }

    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds (0.16f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Death");
        StopAllCoroutines();
    }

}
