using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D rigidBody;
        public float horizontalMove;
        private float jumpForce;
        public Vector2 direction;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Move()
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
        }

        private void Update()
        {
            Move();
        }

        private void FixedUpdate()
        {
            direction = new Vector2((horizontalMove * speed), rigidBody.velocity.y);
            rigidBody.velocity = direction;
        }
    }
}
