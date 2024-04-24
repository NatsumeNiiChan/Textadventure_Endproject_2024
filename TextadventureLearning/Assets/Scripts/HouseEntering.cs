using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEntering : MonoBehaviour
{
    public float XCoordinate;
    public float YCoordinate;

    private GameObject player;
    [SerializeField] private bool inHouse;
    [SerializeField] private bool houseTrigger;
    [SerializeField] private bool inTrigger;

    [SerializeField] private AudioClip houseClip;
    [SerializeField] private AudioClip houseMusic;
    [SerializeField] private AudioClip outMusic;
    [SerializeField] private AudioSource outSounds;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sound;

    private void Awake()
    {
        player = GameObject.Find("Player");

        outSounds = GameObject.Find("BGSoundHandler").GetComponent<AudioSource>();
        music = GameObject.Find("MusicHandler").GetComponent<AudioSource>();
        sound = GameObject.Find("SoundHandler").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (inTrigger == true && Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = new Vector2(XCoordinate, YCoordinate);
            inTrigger = false;

            if (inHouse == false && houseTrigger == false)
            {
                outSounds.Play();
                music.clip = outMusic;
                music.Play();
                sound.clip = houseClip;
                sound.Play();
            }

            if (inHouse == true && houseTrigger == false)
            {
                outSounds.Pause();
                music.clip = houseMusic;
                music.Play();
                sound.clip = houseClip;
                sound.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
