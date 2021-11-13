using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //CREADO POR CARLOS RODRIGUEZ.
    public float horizontalInput;
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator animator;

    public ParticleSystem explosion;
    public ParticleSystem escape;

    public AudioClip jumpAudio;
    public AudioClip crashAudio;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.z > -13 && transform.position.z < 13)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 20 * horizontalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;
            animator.SetTrigger("Jump_trig");
        }


    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("Puede saltar nuevamente");
            playerAudio.PlayOneShot(jumpAudio, 1.0f);
        }
        else if (other.gameObject)
        {
            gameOver = true;
            Debug.Log("Juego Terminado");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosion.Play();
            escape.Stop();
            playerAudio.PlayOneShot(crashAudio, 1.0f);
        }

        isOnGround = true;
    }
}
