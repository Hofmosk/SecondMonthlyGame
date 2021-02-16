using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool Start;
    public GameObject UIMenu;
    public GameObject UIControls;
    public GameManager gameManager;
    // Start is called before the first frame update
    void start()
    {
        Start = false;
        UIControls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Start == false)
        {
            Time.timeScale = 0;
            UIMenu.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        gameManager.Paused = false;
        Start = true;
        Time.timeScale = 1;
        UIMenu.SetActive(false);
    }

    
    public void Controls()
    {
        UIMenu.SetActive(false);
        UIControls.SetActive(true);
    }
    public void Return()
    {
        UIControls.SetActive(false);
        UIMenu.SetActive(true);
        
    }
}
