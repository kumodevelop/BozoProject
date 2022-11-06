using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 yVelocity;
    public Vector3 smokePosition;
    float maxHeight = 1f;
    float timeToPeak = 0.3f;

    private GameManager gInstance;

    public float jumpSpeed;
    float gravity;

    bool isGrounded = false;
    public float groundPosition;

    void Start()
    {
        gInstance = GameManager.GetInstance();
        gravity = (2 * maxHeight / Mathf.Pow(timeToPeak, 2));
        jumpSpeed = 8;
    }

     
    void Update()
    {
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if(transform.position.y <= groundPosition)
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && gInstance.gameState == 1)
        {
            yVelocity = jumpSpeed * Vector2.up;
            CallSmoke();
        }

        transform.position += (Vector3)yVelocity * Time.deltaTime;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            gInstance.gameState = 3;
        }
    }

    void CallSmoke()
    {
        SmokePooling.GetInstance().Create(smokePosition, transform.localRotation);
    }

}
