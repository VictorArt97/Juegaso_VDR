using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volumen : MonoBehaviour
{
    [SerializeField]private Slider slider;
    [SerializeField]private float sliderValor;
    

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.2f);
        AudioListener.volume = slider.value; // sacar el volumen del juego y darle el valor del slider (0 a 1)
        RevisarSiEstoyMuteado();
        
    }


    public void ChangeSlider(float valor)
    {
        sliderValor = valor;
        PlayerPrefs.SetFloat("volumenAudio",sliderValor);
        AudioListener.volume= slider.value;
        RevisarSiEstoyMuteado();
    }

    private void RevisarSiEstoyMuteado()  // comprobar si funciona que me avisa de que esta muteada la musica
    {
        if (sliderValor == 0)
        {
            Debug.Log("Estas muteado");
        }
        else
        {
            Debug.Log("No Estas muteado");
        }
    }
}
