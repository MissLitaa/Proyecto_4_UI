using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
   
    public GameObject[] targetPrefabs;
    public Vector3 spawnPoint;

    private float minXPosition = -3.75f;
    private float minYPosition = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int amountRows = 4;
    private float spawnRate = 0.5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    private int score;
    public int missCounter;
    public int totalMisses = 3;

    public List<Vector3> targetPositions;

    private void Start()
    {
        StartCoroutine("SpawnRandomTarget");
        score = 0;
        UpdateScore(0);
        gameoverText.gameObject.SetActive(false);
        missCounter = 0;
    }

    private void isGameOver()
    {
        gameoverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

   

    public Vector3 RandomSpawnPoint()
    {
        //Generamos las posiciones aleatorias en los 16 cuadrados (centros).
        int randomIntX = Random.Range(0, amountRows);
        int randomIntY = Random.Range(0, amountRows);
        float randomPosX = minXPosition + randomIntX * spaceBetweenSquares;
        float randomPosY = minYPosition + randomIntY * spaceBetweenSquares;

        //Guardamos los resultados de arriba en el RandomSpawnPoint gracias al return y al pasar esta función, nos irá haciendo new Vectors.
        return new Vector3(randomPosX, randomPosY, 0);
    }
    
    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, targetPrefabs.Length);
            spawnPoint = RandomSpawnPoint();

            while (targetPositions.Contains(spawnPoint))
            {
                spawnPoint = RandomSpawnPoint();
            }

            Instantiate(targetPrefabs[randomIndex], spawnPoint, targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(spawnPoint);
        }

    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = $"Score : {score} ";
    }
    
}
