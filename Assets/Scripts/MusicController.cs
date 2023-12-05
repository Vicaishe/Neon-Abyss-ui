using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip levelMusic;
    public AudioClip deathMusic;

    private AudioSource audioSource;
    private bool isPlayingDeathMusic = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelMusic;
        audioSource.Play();
    }

    void Update()
    {
        // Проверка на смерть персонажа
        if (GameObject.FindWithTag("Player") == null && !isPlayingDeathMusic)
        {
            audioSource.Stop();
            audioSource.clip = deathMusic;
            audioSource.Play();
            isPlayingDeathMusic = true;
        }
    }
}