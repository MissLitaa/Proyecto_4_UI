using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public GameObject[] targetPrefabs;
    public Vector3 spawnPoint;

    private float minXPosition = -3.75f;
    private float minYPosition = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int amountRows = 4;
    private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine("SpawnRandomTarget");
    }

    public Vector3 RandomSpawnPoint()
    {
        //Generamos las posiciones aleatorias en los 16 cuadrados (centros).
        int randomInt = Random.Range(0, amountRows);
        float randomPosX = minXPosition + randomInt * spaceBetweenSquares;
        float randomPosY = minYPosition + randomInt * spaceBetweenSquares;

        //Guardamos los resultados de arriba en el RandomSpawnPoint gracias al return y al pasar esta función, nos irá haciendo new Vectors.
        return new Vector3(randomPosX, randomPosY, 0);
    }
    
    private IEnumerator SpawnRandomTarget()
    {
        yield return new WaitForSeconds(spawnRate);
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        spawnPoint = RandomSpawnPoint();
        Instantiate(targetPrefabs[randomIndex], spawnPoint, targetPrefabs[randomIndex].transform.rotation);

    }

    
}
