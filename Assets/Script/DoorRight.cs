using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRight : MonoBehaviour
{
    public LevelManagement levelManagement;
    public GameManager gameManager;
    public MainMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log("door"+ levelManagement.DoorOpen);
        if( gameManager.Paused == false && mainMenu.Start)
        {
            if(levelManagement.DoorOpen == false)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 180), 0.005f);
            }

            if(levelManagement.DoorOpen == true)
            {
                
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), 0.005f);
                
            }
        }
    }
}
