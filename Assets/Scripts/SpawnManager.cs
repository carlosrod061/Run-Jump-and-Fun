using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
      //CREADO POR CARLOS RODRIGUEZ.
    public GameObject obstaculoPrefab;
    // Start is called before the first frame update
    private PlayerController scriptPlayer;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2);
       scriptPlayer =
          GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle()
    {
        if (!scriptPlayer.gameOver)
            Instantiate(obstaculoPrefab, new Vector3(35, 0, 0), obstaculoPrefab.transform.rotation);
    }
}
