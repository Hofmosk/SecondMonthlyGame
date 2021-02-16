using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Vector3 InitPos;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InitPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-gameManager.Speed*Time.deltaTime,0,0));
        //Debug.Log("posX "+ transform.position.x);
        if(gameManager.Speed <= 0)
        {
            Debug.Log("HALLO");
            transform.position = InitPos;
        }
        
    }
}
