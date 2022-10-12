/*
 * Zach Wilson
 * Assignment 5A
 * This is a script that controlles the player character and I edited it to update the animator with "velocityY"
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public gameManager gameManagerScript;
    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
    }

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (!gameManagerScript.GameOver)
        {
            move.x = Input.GetAxis("Horizontal");
        }

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && gameManagerScript.GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (move.x > 0.01f)
        {
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        else if (move.x < -0.01f)
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
        animator.SetFloat("velocityY", velocity.y);

        targetVelocity = move * maxSpeed;
    }
}