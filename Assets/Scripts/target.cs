using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private float destroyTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        {
            Destroy(gameObject); 
            //Dar puntos, SP, AS.
        }

        else if (gameObject.CompareTag("Bad"))
        {
            //Parar juego o restar puntos, o no contar puntuación, quitar vida, musiquita de game over o mal hecho, SP.
            Destroy(gameObject);
        }
        
    }
}
