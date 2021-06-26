using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float speed = default;
    public int jumpForce = default;
    public Transform groundDetection = default;
    public LayerMask groundLayer = default;
    public AudioSource jumpSound;
    public GameObject Play, Pause, Won, Lost;

    private bool onGround;
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private SpriteRenderer playerSprite;
    private bool playerJumping;
    private float playerMovement;
    private bool playerRightSide;

    void Start(){
        onGround = false;
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerJumping = false;
        playerMovement = 0;
        playerRightSide = true;
    }

    void Update(){
        if (!Play.activeSelf && !Pause.activeSelf && !Lost.activeSelf){
            onGround = Physics2D.OverlapCircle(groundDetection.position, 1f, groundLayer);
            if (onGround){
                if(Input.GetButtonDown("Jump")){
                    playerJumping = true;
                }
            }                         
        }
        Animations();
    }

    private void FixedUpdate(){
        playerMovement = 0f;
        if (!Play.activeSelf && !Pause.activeSelf && !Lost.activeSelf){
            if(playerJumping){
                playerJumping = false;
                playerRigidBody.AddForce(new Vector2(0f, jumpForce));
                playerAnimator.SetTrigger("Jump");
                if (jumpSound != null){
                    jumpSound.Play();
                }
            }
            playerMovement = Input.GetAxis("Horizontal");
            playerRigidBody.velocity = new Vector2(playerMovement * speed, playerRigidBody.velocity.y);
        }else{
            playerRigidBody.velocity = new Vector2(0f, 0f);
        }
        SwapSprite();
    }

    void Animations(){
        if (onGround){
            if(playerMovement != 0){
                playerAnimator.SetBool("Run", true);
            }else{
                playerAnimator.SetBool("Run", false);
            }
        }else{
            playerAnimator.SetBool("Run", false);

            if(playerRigidBody.velocity.y < 0){
                playerAnimator.ResetTrigger("Jump");
            }
        }
    }

    void SwapSprite(){
        if((playerMovement < 0 && playerRightSide) || (playerMovement > 0 && !playerRightSide)){
            playerRightSide = !playerRightSide;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
