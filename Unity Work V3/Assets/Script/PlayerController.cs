using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody rb;
    private Animator playerAnim;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float gravityModifier = 50f;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] public bool gameOver = false;
    public Text GameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem DirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        GameOver.enabled = false;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
          
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //ForceMode.Impulse: Rigidbody Componentine sahip objelere bir kuvvet ekler. 
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            DirtSplatter.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            DirtSplatter.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            GameOver.enabled = true;
            explosionParticle.Play();
            DirtSplatter.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }
}
