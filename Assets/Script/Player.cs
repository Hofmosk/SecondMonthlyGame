using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool onTheGround;
    private bool onTheWall;
    private float leftRight;
    private bool isJumping;
    public float JumpSpeed;
    public Transform Feetpos;
    public bool Death;

    public float jumpTime;
    private float jumpTimeCounter;

    private float tamponJump;
    public AudioSource M_Death;
    public AudioSource M_Jump;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tamponJump = JumpSpeed;
        jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Raycasting
        onTheGround = Physics.Raycast(Feetpos.position,Vector3.down, 0.335f);
        onTheWall = Physics.Raycast(Feetpos.position,new Vector3(0,0,leftRight), 0.370001f);
 

        //Don't be stuck in the ground
        if(onTheGround == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            
        }

        //JUMP
         if(Input.GetKeyDown(KeyCode.Space) && onTheGround == true)
        {
            M_Jump.Play();
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector3(rb.velocity.x, 1*JumpSpeed,rb.velocity.z);
   
        }

         if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter >= 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, (1*JumpSpeed),rb.velocity.z);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping =false;
        }
        
        //Death Condition
        if(transform.position.y <= -1)
        {
            M_Death.Play();
            transform.position = new Vector3(-33, 0.4f, 0);
            Death = true;
        }
    }

    void FixedUpdate()
    {
        //Gestion déplacement
        if(Input.GetKey(KeyCode.Q)||Input.GetKey(KeyCode.LeftArrow))
        {
            leftRight=0.1f;
            rb.velocity = new Vector3(0,rb.velocity.y,Speed * Time.deltaTime); 
        }
        if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            leftRight=-0.1f;
            rb.velocity = new Vector3(0,rb.velocity.y,Speed * -Time.deltaTime);
        }

        if(onTheWall==true)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,0);
        }


        //Gestion Saut
       
    }
}
