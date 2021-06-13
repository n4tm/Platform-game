using UnityEngine;
using UnityEngine.SceneManagement;

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
        public bool isJumping;
        private bool canDoubleJump;

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
            if (Input.GetButtonDown("Jump"))
            {
                if (!isJumping)
                {
                    rigidBody.AddForce(jumpForce, ForceMode2D.Impulse);
                    isJumping = true;
                    canDoubleJump = true;
                }
                else if (canDoubleJump)
                {
                    rigidBody.AddForce(jumpForce, ForceMode2D.Impulse);
                    canDoubleJump = false;
                }
                
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == 7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (other.gameObject.layer == 6)
            {
                isJumping = false;
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
