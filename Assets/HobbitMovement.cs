using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobbitMovement : MonoBehaviour
{
    [SerializeField] AudioSource audioSource1;
    [SerializeField] AudioSource audioSource2;

    public float speed = 0;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    public ParticleSystem dust;


    private SoundManager soundManager;


    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        dust = FindObjectOfType<ParticleSystem>();
    }
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();


    }

    void Update()
    {
        //inputs

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);


        //CheckParticle();


    }

    private void FixedUpdate()
    {
        //Físicas

        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);

    }

    private void WalkSound()
    {
        SoundManager.PlaySound("Player_Footstep", audioSource1);
    }

    //private void CheckParticle()
    //{
    //    if (speed != 0)
    //    {
    //        dust.Play();
    //    }
    //    else
    //    {
    //        dust.Pause();
    //    }
    //}

    private void PlayParticle() => dust.Play();

    private void StopParticle() => dust.Stop();
}
