using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PlayerTrap : MonoBehaviour
{

    private Vector2 lastLocation;
    public int playerHealth = 3;
    private float hurt = 5f;
    private Rigidbody2D rb;

    //Add reference (link) to the UI text.
    public TextMeshProUGUI textHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Just incase a trap is hit before a checkpoint is reached.
        lastLocation = transform.position;

        textHealth.text = "Health: " + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        textHealth.text = "Health: " + playerHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Trap")
        {
            playerHealth--;
            if (playerHealth < 1 )
            {
                Debug.Log("Oh no!");
                transform.position = lastLocation;
                playerHealth = 3;
            }
            
        }

        if (collision.tag == "Checkpoint")
        {
            lastLocation = collision.transform.position;
            Debug.Log("Checkpoint reached!" + lastLocation);
            playerHealth = 3;
        }

        if (collision.tag == "Death Zone")
        {
            playerHealth = playerHealth - 3;
            if (playerHealth < 1)
            {
                Debug.Log("Oh no!");
                transform.position = lastLocation;
                playerHealth = 3;
            }

        }

    }

}
