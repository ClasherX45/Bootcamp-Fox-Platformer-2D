using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class PlayerCollectible : MonoBehaviour
{
    //Add reference (link) to the UI text.
    public TextMeshProUGUI textUI;

    public int gemsCollected = 0;

    //Make a reference link to Sound Controller script.
    public SoundController theSoundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Sets the value of the UI text.
        textUI.text = "Gems: " + gemsCollected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detects when the player is colliding with an on trigger object. It should not be under update or start.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Collectible")
        {
            //Plays collect sound.
            gemsCollected++;
            //Sets the value of the UI text.
            textUI.text = "Gems: " + gemsCollected;
            theSoundController.collect();
            collision.gameObject.GetComponent<Animator>().SetBool("isCollected", true);
            StartCoroutine(ExecuteDelayed(() => Destroy(collision.gameObject)));
            
            
        }



    }
    public IEnumerator ExecuteDelayed(Action code)
    {
        yield return new WaitForSeconds(1);
        // Execute delayed code
        code();
    }


}
