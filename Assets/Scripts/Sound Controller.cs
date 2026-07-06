using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioSource Jump;
    public AudioSource Collect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jump()
    {
        Jump.Play();
    }

    public void collect()
    {
        Collect.Play();
    }

}
