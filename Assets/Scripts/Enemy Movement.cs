using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float hitDist = 1f;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    private bool goingRight = true;

    Renderer m_Renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocityX = speed;

        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(speed));

            if (goingRight)
            {
                GetComponent<Rigidbody2D>().linearVelocityX = speed;
                if (Physics2D.Raycast(transform.position, Vector2.right, hitDist, groundLayer) || Physics2D.Raycast(transform.position, Vector2.right, hitDist, enemyLayer))
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    GetComponent<Rigidbody2D>().linearVelocityX = -speed;
                    goingRight = false;
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().linearVelocityX = -speed;
                if (Physics2D.Raycast(transform.position, Vector2.left, hitDist, groundLayer) || Physics2D.Raycast(transform.position, Vector2.left, hitDist, enemyLayer))
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    GetComponent<Rigidbody2D>().linearVelocityX = speed;
                    goingRight = true;
                }
            }
        }



    }

}
