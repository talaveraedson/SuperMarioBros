using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Mario; //It's used for access to the Mario GameObject and follow him

    void Update() //It checks if Mario GameObject exists is true, the camera follow Mario otherwise the camera doesn't move.
    {
        if (Mario != null)
        {
            Vector3 position = transform.position;
            position.x = Mario.transform.position.x;
            transform.position = position;
        }
    }



    /*
    public GameObject jugador;
    public Vector2 minimo;
    public Vector2 maximo;
    public float suavizado;
    Vector2 velocity;


    
    void FixedUpdate()
    {
        if (jugador != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, jugador.transform.position.x, ref velocity.x, suavizado);
            float posY = Mathf.SmoothDamp(transform.position.y, jugador.transform.position.y, ref velocity.y, suavizado);

            transform.position = new Vector3(Mathf.Clamp(posX, minimo.x, maximo.x), Mathf.Clamp(posY, minimo.y, maximo.y), transform.position.z);
        }
        }
    */
}
