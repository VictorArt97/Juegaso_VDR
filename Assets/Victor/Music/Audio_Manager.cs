using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    
    
    
    void ReproducirSonido(AudioClip SonidoBoton)
    {
        sfx.PlayOneShot(SonidoBoton);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
