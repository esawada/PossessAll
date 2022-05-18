using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovementController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 1;
    public float jumpForce = 1;
    public bool isJumping = true;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * (Time.deltaTime * speed);

        float inputAxis = Input.GetAxis("Horizontal");

        if (inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(isJumping) return;
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
