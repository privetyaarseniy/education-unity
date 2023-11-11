using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;

    Animator playerAnim;

    AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    readonly float upperBound = 6.5f;
    public float jumpForce;
    public float gravityModifier;
    public bool dashActive;

    public bool gamePause = true;

    bool isOnGround = true;
    int jumpCounter;
    float score;

    readonly float introEndPos = 0f;
    readonly float introDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        StartCoroutine(Intro());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= upperBound) transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);

        dashActive = false;
        score += 1 * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && !gamePause && (jumpCounter < 2 || isOnGround))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
            jumpCounter++;
        }

        if(Input.GetKey(KeyCode.D) && isOnGround)
        {
            dashActive = true;
            score += 1 * Time.deltaTime;
        }

        if (!gamePause) Debug.Log($"Score: {(int)score}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCounter = 0;
            dirtParticle.Play();
        }
        else
        {
            gamePause = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true); // enabling death animation according to its conditions
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("GAME OVER!");
            playerAudio.PlayOneShot(crashSound);
        }
    }

    IEnumerator Intro()
    {
        float elapsedTime = 0f;
        float startPos = transform.position.x;
        dirtParticle.enableEmission = false;

        while(elapsedTime <= introDuration)
        {

            transform.position = new Vector3(Mathf.Lerp(startPos, introEndPos, elapsedTime / introDuration), transform.position.y, transform.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        dirtParticle.enableEmission = true;
        gamePause = false;
    }
}
