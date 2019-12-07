using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOne : MonoBehaviour
{
    public Slider playerOneHealthBar;
    private Rigidbody2D rigidBody;

    public static int Health { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        PlayerMovement.isFacingRight = true;

        Health = 100;
        playerOneHealthBar.value = Health;
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement.MoveHorizontalPlayerOne(rigidBody, transform);
        PlayerMovement.JumpPlayerOne(rigidBody);
        PlayerMovement.CheckBounds(transform);
        PlayerDamage.TakeDamagePlayerOne(playerOneHealthBar);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollision.CollidingWithPlatform(collision, "platform");
        PlayerCollision.CollidingWithPlayer(collision, "playerTwo");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "platform")
        {
            PlayerMovement.isGrounded = false;
        }

        if (collision.gameObject.name == "playerTwo")
        {
            print("PlayerOne not collides with PlayerTwo");
            
        }
    }
}
