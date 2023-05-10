using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] powerups;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void SpawnRoutines()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnEnemy()
    {
        while (gameManager.gameOver == false)
        {
            Instantiate(enemy, new Vector3(Random.Range(-7, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(5f);

        }
    }
    IEnumerator SpawnPowerups()
    {
        while (gameManager.gameOver == false)
        {
            var randPower = Random.Range(0, powerups.Length);
            Instantiate(powerups[randPower], new Vector3(Random.Range(-7, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
