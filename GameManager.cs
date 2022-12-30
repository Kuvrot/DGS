using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public int killCount;

    static public GameObject player;
    static public PlayerStats playerStats;
    static public ShootingSystem shootingSystem;
    public GameObject _player;
    public GameObject _playerManager;
    static public GameObject playerManager;

    static public GameObject bullet;
    public GameObject _bullet;

    [Header("FX")]
    static public GameObject hitFX;
    public GameObject _hitFX;
    static public GameObject bloodHitFX;
    public GameObject _bloodHitFX;
    static public GameObject explosionFX;
    public GameObject _explosionFX;



    // Start is called before the first frame update
    void Awake()
    {
        killCount = 0;

        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        player = _player;

        playerStats = _player.GetComponent<PlayerStats>();


         if (_playerManager == null)
        {
            _playerManager = GameObject.FindGameObjectWithTag("Manager");
        }   

         playerManager = _playerManager;

        shootingSystem = playerManager.GetComponent<ShootingSystem>();

        bullet = _bullet;

        hitFX = _hitFX;
        bloodHitFX = _bloodHitFX;

        explosionFX = _explosionFX;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ExitLevel()
    {
        Destroy(gameObject);
    }
}
