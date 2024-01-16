using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    public List<GameObject> enemies_list;

    public int curEnemies;
    
    public bool isWaveActive = false;
    bool waveActive;


    public int wave = 0;

    public int enemies;
    public int killCount;

    //This is the number of spawns 
    public int spawnNumber = 1;

    float seconds = 10;
    float curSeconds;

    //UI stuff
    public Text waveN;

    //Components 
    AudioSource asrce;
    MusicManager mm;

    // Start is called before the first frame update
    void Start()
    {

        waveActive = false;

        if (!isWaveActive)
        {
            StartCoroutine(timeToNextWave());
        }

        asrce = GetComponent<AudioSource>();
        mm = GetComponent<MusicManager>();

    }

    // Update is called once per frame
    void Update()
    {

        killCount = GameManager.killCount;


        if (enemies_list.Count > 0) { waveActive = true; }
      

        if (isWaveActive)
        {
            waveN.text = "Wave: " + (wave + 1).ToString();
            waveN.fontSize = 93;

            if (!asrce.isPlaying)
            {
                playMusic();
            }

          if (waveActive)
            {
                if (enemies_list.Count == 0 && curEnemies >= enemies)
                {
                    isWaveActive = false;

                    StartCoroutine(timeToNextWave());
                }
            }

        }
        else
        {
            waveN.fontSize = 64;
            waveN.text = "Next wave starts soon";
        }

       
  
    }

    IEnumerator timeToNextWave()
    {
        yield return new WaitForSeconds(seconds);
        wave++;
        enemies += Mathf.RoundToInt(3 * Mathf.Sin(wave - 1.4f) + 3) + wave * 3;
        isWaveActive = true;
        curEnemies = 0;
        waveActive = false;
        StopAllCoroutines();
    }

    void playMusic()
    {

        int ran = Random.Range(0, mm.musicDataBase.Length);

        asrce.PlayOneShot(mm.musicDataBase[ran]);

    }

}
