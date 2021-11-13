using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
      //CREADO POR CARLOS RODRIGUEZ.
    private float speed = 30;
    private PlayerController scriptPlayer;
    // Start is called before the first frame update
    void Start()
    {
        scriptPlayer =
          GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (!scriptPlayer.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

    }
}
