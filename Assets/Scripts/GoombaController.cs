using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public GameObject Mario; //Declarate the game object for give access to Mario Object and interacts with enemies

    void Update()
    {
        if (Mario == null) return; //refers to Mario destroyed the object is deleted of memory
        
        Vector3 direction = Mario.transform.position - transform.position; //You need to add the codes for move the enemy
        //This is the activity for this week
        if (direction.x <= 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        
    }

    private void OnCollisionEnter2D(Collision2D collision) //We call to collider component and detects a coliision with other objects by the collision parameter
    {
        MarioController mario = collision.collider.GetComponent<MarioController>();
        if (mario != null) //if it detects a collision with Mario, it calls the Hit method, then it gets destroyed
        {
            mario.Hit();
        }
    }

}
