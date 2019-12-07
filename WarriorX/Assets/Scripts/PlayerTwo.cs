using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwo : MonoBehaviour
{
    public Slider playerTwoHealthBar;
    private Rigidbody2D rigidBody;

    public static int Health { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        PlayerMovement.isFacingLeft = true;

        Health = 100;
        playerTwoHealthBar.value = Health;
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement.MoveHorizontalPlayerTwo(rigidBody, transform);
        PlayerMovement.JumpPlayerTwo(rigidBody);
        PlayerMovement.CheckBounds(transform);
        PlayerDamage.TakeDamagePlayerTwo(playerTwoHealthBar);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollision.CollidingWithPlatform(collision, "platform");
        PlayerCollision.CollidingWithPlayer(collision, "playerOne");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "platform")
        {
            PlayerMovement.isGrounded = false;
        }

        if (collision.gameObject.name == "playerOne")
        {
            print("PlayerTwo not collides with PlayerOne");
        }
    }
}
