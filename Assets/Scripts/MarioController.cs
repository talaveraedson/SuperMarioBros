using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    //Speed is for control the movements per pixel
    public float speed = 5.0f; //5.0f refers to move the player 5 pixels per second
    public float jumpforce; //refers to Jump the player and value change of hardware
    private float horizontal; //refers to scale property of the transform component
    private bool Grounded; //refers to collision between Ground and Mario object
    public Rigidbody2D m_rigidBody; // used for access to property of the Mario object
    private Animator m_animator; // used for access to property of the Mario animator eg.Idle and Walk
    private int Health = 1; //It is used in order to have a control of the lives you have in the game


    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>(); //Instance component RigidBody 
        m_animator = GetComponent<Animator>(); //Instance the animator

    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red); //Refers to show the vector that generates collision between MarioObject and Ground
        m_animator.SetBool("Walk", horizontal != 0.0f); //Use the instance of the animator for event "Walk", if horizontal is different of 0 then we execute the event Walk

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); //Here we check if Mario move to left then we change the sprite in Scale properties
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); //Here we check if Mario move to right then we change the sprite in Scale properties

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f)) //If Raycast component detects a collision between Mario and Ground, the variable Grounded take the value of 2, if not Grounded take the value of false
        {
            Grounded = true;
        } else 
        Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded) //If you press buttom space and Grounded is true, Mario executes Jump action
        {
            m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, jumpforce);
            print("space key was pressed");
        }

    }

    
    public void Hit() //It's a method we control the lives of Mario
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject); //If the lives goes to 0, Mario get destroy
    }

    void FixedUpdate() //We take the control of the keyboard in order to move the Mario
    {
        horizontal = Input.GetAxis("Horizontal");
        m_rigidBody.velocity = new Vector2(horizontal * speed, m_rigidBody.velocity.y);
    }
   

}
