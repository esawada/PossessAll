using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class GhostMovementController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float Speed = 1;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * (Time.deltaTime * Speed);
        
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
}