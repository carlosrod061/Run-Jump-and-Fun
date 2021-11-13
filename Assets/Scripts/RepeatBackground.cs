using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
      //CREADO POR CARLOS RODRIGUEZ.
    private Vector3 startPos;
    private float ancho;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        ancho = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - 40)
        {
            transform.position = startPos;
        }
    }
}
