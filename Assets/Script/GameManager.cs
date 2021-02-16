using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LevelManagement levelManagement;
    public MainMenu mainMenu;
    private int rotateValue;
    public float timeToRotate;
    public bool isRotate;
    public int goalRotation;
    public float Speed;
    public float BaseSpeed;
    public bool Paused;
    public GameObject UIPause;
    public AudioSource M_MainAudio;
    public AudioSource M_Turn;
    
    public Transform from;
    
    // Start is called before the first frame update
    void Start()
    {   
        UIPause.SetActive(false);
        Paused = true;
        goalRotation = 0;
        BaseSpeed = Speed;
        M_MainAudio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        from = levelManagement.TransformLevel[levelManagement.NbLevel];
        from.Translate(new Vector3(-Speed*Time.deltaTime,0,0));
        //from.position = (Vector3.Lerp(from.position, new Vector3(levelManagement.LevelLocation.x-200 , levelManagement.LevelLocation.y, levelManagement.LevelLocation.z), 0.0004f));

        if(isRotate == false)
        {
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {    
                M_Turn.Play();
                goalRotation -= 90;
                isRotate = true;
            }
            if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                M_Turn.Play();
                goalRotation += 90;
                isRotate = true;
            }
        }
       
       Debug.Log("paused "+ Paused);
       if(Input.GetKeyDown(KeyCode.Escape) && mainMenu.Start == true)
       {   
           Paused = !Paused;
           if(Paused == false)
           {
                Time.timeScale = 1;
                UIPause.SetActive(false);
                //Menu Pause Visible
           }
           if(Paused == true)
           {
                UIPause.SetActive(true);
                Time.timeScale = 0;
           }

       }
        
    }

    void LateUpdate()
    {
        if(isRotate == true)
        {
            ToRotate();
        }
        if(from.rotation == Quaternion.Euler(goalRotation,0,0))
        {
            isRotate = false;
        }

    }

    private void ToRotate()
    {
        if(isRotate == true)
        {
            
            from.rotation = Quaternion.Lerp(from.rotation, Quaternion.Euler(goalRotation,0,0), Time.deltaTime * 20f);
            
        }
    }

    public void Continue()
    {
        UIPause.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }

    public void MainMenu()
    {
        UIPause.SetActive(false);
        Time.timeScale = 0;
        Paused = true;
        mainMenu.UIMenu.SetActive(true);
    }

   
}
