using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovement
{
    public static float moveSpeed = 10f;
    public static float jumpSpeed = 30f;

    public static bool isFacingRight;
    public static bool isFacingLeft;
    public static bool isGrounded;
    public static bool moveRight;
    public static bool moveLeft;

    public static void MoveHorizontalPlayerOne(Rigidbody2D rigidBody, Transform transform)
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        // rigidBody.velocity = new Vector2(moveHorizontal * PlayerMovement.moveSpeed, rigidBody.velocity.y);

        moveLeft = Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.D);

        if (moveLeft)
        {
            rigidBody.velocity = new Vector2(moveSpeed * -1, rigidBody.velocity.y);
        }

        if (moveRight)
        {
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        }

        // If player pressing D
        if (moveRight && !isFacingRight)
        {
            FlipDirection(transform);
        }

        // If player pressing A
        if (moveLeft && isFacingRight)
        {
            FlipDirection(transform);
        }
    }

    public static void MoveHorizontalPlayerTwo(Rigidbody2D rigidBody, Transform transform)
    {
        moveLeft = Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);

        if (moveLeft)
        {
            rigidBody.velocity = new Vector2(moveSpeed * -1, rigidBody.velocity.y);
        }

        if (moveRight)
        {
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        }

        // If player pressing RightArrow
        if (moveRight && isFacingLeft)
        {
            FlipDirection(transform);
        }

        // If player pressing LeftArrow
        if (moveLeft && !isFacingLeft)
        {
            FlipDirection(transform);
        }
    }

    public static void FlipDirection(Transform transform)
    {
        isFacingRight = !isFacingRight;
        isFacingLeft = !isFacingLeft;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public static void JumpPlayerOne(Rigidbody2D rigidBody)
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rigidBody.velocity = Vector2.up * jumpSpeed;
        }
    }

    public static void JumpPlayerTwo(Rigidbody2D rigidBody)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rigidBody.velocity = Vector2.up * jumpSpeed;
        }
    }

    public static void CheckBounds(Transform transform)
    {
        if (transform.position.x <= -12.5f)
        {
            transform.position = new Vector3(-12.5f, transform.position.y, transform.position.z);
        }

        else if (transform.position.x >= 12.5f)
        {
            transform.position = new Vector3(12.5f, transform.position.y, transform.position.z);
        }
    }
}


