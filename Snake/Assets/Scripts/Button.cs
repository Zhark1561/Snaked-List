using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnStartGame()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    
}
