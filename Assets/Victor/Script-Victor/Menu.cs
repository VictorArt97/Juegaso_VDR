using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderData;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;
    private bool pausa;

    [SerializeField] AudioClip sonidoApretar;
    [SerializeField] Audio_Manager manager;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == false)
            {
                pausa = true;
                menuPausa.SetActive(true);

                Time.timeScale = 0f;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
        }
    }

    public void Reanudar ()
    {
        menuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Empezar()
    {
        
        SceneManager.LoadScene(2);
    }
    public void Configuracion()
    {
        
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        
        Application.Quit();
    }
}
