using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerCollision
{
    public static void CollidingWithPlatform(Collision2D collision, string platform)
    {
        if (collision.collider.tag == platform)
        {
            PlayerMovement.isGrounded = true;
            Debug.Log("Ground collision");
        }
    }
     
    public static void CollidingWithPlayer(Collision2D collision, string player)
    {
        if (collision.gameObject.name == player)
        {
            Debug.Log("Player collsion");
        }
    }
}
