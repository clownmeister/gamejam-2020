using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    [Header("Bullet settings")] 
    public GameObject bulletDeathParticleSystem;
    public GameObject debugPlatform;
    public float bulletSpeed;
    public float bulletTTL;
    public float bulletFalloff;

    public Transform respawnPoint;
    public GameObject Player;

    public AudioClip musicLoop;
    private AudioSource audioS;
    private bool finishedIntro = false;
    void Awake()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!finishedIntro && !audioS.isPlaying)
        {
            audioS.loop = true;
            audioS.PlayOneShot(musicLoop);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Player.transform.position = respawnPoint.position;
            Player.transform.rotation = respawnPoint.rotation;
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
