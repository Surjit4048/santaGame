using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 20f;
    public float movement = 0f;
	public float jumpSpeed = 5f;
    public Vector3 reSwanPoint;

	private bool isGrounded = true;
    private Rigidbody2D playerBody;
    private Animator playerAnimation;
    private SpriteRenderer mySpriteRenderer;


    // Use this for initialization
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        reSwanPoint = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("jump") && isGrounded)
		{
			playerBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
			playerAnimation.SetBool("jump", true);
			isGrounded = false;
		}

        movement = Input.GetAxis("Horizontal");
		playerAnimation.SetFloat("speed", movement);

        if (movement < -0.1)
        {
            mySpriteRenderer.flipX = true;
            playerBody.velocity = new Vector2(movement * speed, playerBody.velocity.y);
		}
        else if (movement > 0.1)
		{
            mySpriteRenderer.flipX = false;
			playerBody.velocity = new Vector2(movement * speed, playerBody.velocity.y);
		}

		if (movement < 0)
		{
			mySpriteRenderer.flipX = true;
			
		}
		else if (movement > 0)
		{
			mySpriteRenderer.flipX = false;	
		}


	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        playerAnimation.SetBool("jump", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WaterTag"){
			transform.position = reSwanPoint;
        }
    }
}
 