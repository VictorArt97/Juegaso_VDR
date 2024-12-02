using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip[] musics;
    [SerializeField] AudioSource musicAudioSource;


    private int indiceActual;
    private float timer;
    void ReproducirSonido(AudioClip SonidoBoton)
    {
        sfx.PlayOneShot(SonidoBoton);
    }

    void Start()
    {
        ReproducirMusicaAleatoria();
    }

    private void ReproducirMusicaAleatoria()
    {
        indiceActual = Random.Range(0, musics.Length);
        musicAudioSource.clip = musics[indiceActual];
        musicAudioSource.Play();
        timer = musicAudioSource.clip.length;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            ReproducirMusicaAleatoria();
        }
    }
}
