using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float _JumpForce;
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void Move()
    {
        Vector3 _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += _movement * (Time.deltaTime * Speed);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0f, _JumpForce), ForceMode2D.Impulse);
    }
}
