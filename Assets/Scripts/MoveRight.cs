using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{

    public float speed = 40.0f;
    public ParticleSystem explosion;
    private GameManager gameManager;
    public AudioClip crashAudio;
    public AudioSource playerAudio;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            playerAudio.PlayOneShot(crashAudio, 1.0f);

            gameManager.UpdateScore(1);
        }
    }
}
