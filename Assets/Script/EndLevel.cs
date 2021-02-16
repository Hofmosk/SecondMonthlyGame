using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public LevelManagement levelManagement;
    public GameManager gameManager;
    private float timer=3f;
    private float counter;
    private bool levelIsEnd;

    // Start is called before the first frame update
    void Start()
    {
        counter = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelIsEnd == true)
        {
            gameManager.Speed *= 0.99f;
            if(gameManager.Speed <= 0.1f)
            {
                gameManager.Speed = 0;
                levelManagement.NbLevel ++;
                levelManagement.SpawnLevel();
                
                levelIsEnd = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        levelIsEnd = true;
        
    }
}
