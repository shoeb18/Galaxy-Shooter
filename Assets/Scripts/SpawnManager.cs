using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject[] powerups;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerups());
    }

    IEnumerator SpawnEnemy()
    {
        while (FindObjectOfType<Player>() != null)
        {
            Instantiate(enemy, new Vector3(Random.Range(-7, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(5f);

        }
    }
    IEnumerator SpawnPowerups()
    {
        while (FindObjectOfType<Player>() != null)
        {
            var randPower = Random.Range(0, powerups.Length);
            Instantiate(powerups[randPower], new Vector3(Random.Range(-7, 7), 7), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
