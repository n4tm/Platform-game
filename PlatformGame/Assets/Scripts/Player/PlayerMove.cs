using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D rigidBody;
        public float horizontalMove;
        private Vector2 jumpForce;
        [SerializeField] private float jumpIntensity;
        public Vector2 direction;
        public bool canJump;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Move()
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
        }

        private void Jump()
        {
            if (Input.GetButtonDown("Jump") && canJump)
            {
                rigidBody.AddForce(jumpForce, ForceMode2D.Impulse);
                canJump = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 6)
            {
                canJump = true;
            }
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void FixedUpdate()
        {
            direction = new Vector2(horizontalMove * speed, rigidBody.velocity.y);
            rigidBody.velocity = direction;
            jumpForce = new Vector2(0f, jumpIntensity);
        }
    }
}
