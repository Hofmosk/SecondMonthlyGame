using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    public List<GameObject> Level;
    public List<GameObject> InstLevel;
    public List<Transform> TransformLevel;
    public Vector3 LevelLocation;
    public int NbLevel = 0;

    public GameObject UINextLevel;
    public GameManager gameManager;
    public Transition transition;
    public Player player;
    public bool DoorOpen;
    public float Timer;
    private float counter;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnLevel();
        UINextLevel.SetActive(false);
        counter = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Death == true)
        {
            DoorOpen = true;
            InstLevel[NbLevel].transform.position = new Vector3(LevelLocation.x -20, LevelLocation.y, LevelLocation.z);
            transition.transform.position = new Vector3(transition.InitPos.x -20, transition.InitPos.y, transition.InitPos.z);
            player.Death = false;
        }

        if(DoorOpen == true)
        {
            counter -= Time.deltaTime;
            if(counter <= 0)
            {
                DoorOpen = false;
            }
        }
    }
    public void SpawnLevel()
    {
        InstLevel.Add(Instantiate(Level[NbLevel], LevelLocation, Quaternion.identity));
        TransformLevel.Add(InstLevel[NbLevel].transform);
        Destroy(Level[NbLevel]);
        UINextLevel.SetActive(true);
        
    }

    public void NextLevel()
    {
        counter = Timer;
        DoorOpen = true;
        gameManager.Speed = gameManager.BaseSpeed;
        UINextLevel.SetActive(false);
    }
    

}
