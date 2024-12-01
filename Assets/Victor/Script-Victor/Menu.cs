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
            SceneManager.LoadScene(1);
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
        new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(2);
    }
    public void Configuracion()
    {
        new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        new WaitForSecondsRealtime(3);
        Application.Quit();
    }
    public void TittleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
