using Unity.VisualScripting;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public float jumpSpeed = 10;
    public float speed = 10;

    //Variable for detecting how far the ground is from the center of player.
    public float groundDist = 1.2f;

    //Add a variable to keep track of whether we are grounded.
    private bool grounded = true;

    //Adds a layer mask for detecting the ground layer.
    public LayerMask groundLayer;

    //Make a reference link to Sound Controller script.
    public SoundController theSoundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        //Checks if the player is grounded.
        IsGrounded();

        if (Input.GetKeyUp(KeyCode.Space) && grounded == true)
        {
            GetComponent<Rigidbody2D>().linearVelocityY = jumpSpeed;
            //Plays jump sound.
            theSoundController.jump();
        }

        //Moves character left and right.
        float horSpeed = Input.GetAxisRaw("Horizontal") * speed;
        GetComponent<Rigidbody2D>().linearVelocityX = horSpeed;

        //Tell the animator what our current speed is.
        //The first argument is the name of the parameter, which we called Speed.
        //The second argument is the value.
        //Uses absolute value to ensure the value of Speed is always positive.
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(horSpeed));


        //If character is moving to the right, keep the sprite on its original side.
        if (GetComponent<Rigidbody2D>().linearVelocityX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //If character is moving to the right, flip the sprite on its X axis.
        else if (GetComponent<Rigidbody2D>().linearVelocityX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    private void IsGrounded() 
    {
        //Debug.DrawRay(transform.position, Vector2.down * groundDist, Color.black);
        if (Physics2D.Raycast(transform.position, Vector2.down, groundDist, groundLayer))
        {
            grounded = true;
            //if i'm grounded, i'm not jumping
            //tell the animator component
            GetComponent<Animator>().SetBool("isJumping", false);
            GetComponent<Animator>().SetBool("isFalling", false);
        }
        else
        {
            grounded = false;
            //if i'm not grounded, i am jumping
            //tell the animator component
            GetComponent<Animator>().SetBool("isJumping", true);
            if (GetComponent<Rigidbody2D>().linearVelocityY < 0)
            {
                GetComponent<Animator>().SetBool("isJumping", false);
                GetComponent<Animator>().SetBool("isFalling", true);
            }
            else if (GetComponent<Rigidbody2D>().linearVelocityY > 0)
            {
                GetComponent<Animator>().SetBool("isFalling", false);
            }
        }
    }


}
