using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private float destroyTimer = 2f;
    private GameManager gameManagerScript;
    [SerializeField] private int points;
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTimer);
       
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        {
            gameManagerScript.UpdateScore(points);
            Destroy(gameObject);
            
            
            //Dar puntos, AS.
            
        }

        else if (gameObject.CompareTag("Bad"))
        {
            //Parar juego o restar puntos, o no contar puntuación, quitar vida, musiquita de game over o mal hecho, SP.
            Destroy(gameObject); 

            gameManagerScript.missCounter += 1;

            if (gameManagerScript.missCounter > gameManagerScript.totalMisses)
            {
                gameManagerScript.isGameOver = true;
            }
            
        }

        if (!gameManagerScript.isGameOver)
        { 
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
        }
        
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }
}
