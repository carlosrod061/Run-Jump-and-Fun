using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //CREADO POR CARLOS RODRIGUEZ.
    public GameObject[] obstaclesPrefabs;
    private float startDelay = 1;
    private float spawnInterval = 0.5f;
    public GameObject obstaculoPrefab;
    // Start is called before the first frame update
    private PlayerController scriptPlayer;
    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay, spawnInterval);
        scriptPlayer =
           GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        int positionZ = Random.Range(-7, 7);
        if (!scriptPlayer.gameOver)
            Instantiate(obstaclesPrefabs[obstacleIndex], new Vector3(40, 0, positionZ), obstaclesPrefabs[obstacleIndex].transform.rotation);
    }
}
