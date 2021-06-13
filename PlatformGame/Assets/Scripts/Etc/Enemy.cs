using UnityEngine;
using UnityEngine.SceneManagement;

namespace Etc
{
    public class Enemy : MonoBehaviour
    {
        private float direction = 1;
        [SerializeField] private float speed;
        [SerializeField] private Transform headPoint;
        private Animator anim;
        private static readonly int die = Animator.StringToHash("die");
        private BoxCollider2D boxCollider2D;
        private Rigidbody2D rig;
        

        private void Start()
        {
            anim = GetComponent<Animator>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            rig = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (transform.position.x < 3.82 || transform.position.x > 7.15)
            {
                direction *= -1f;
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            }
            transform.Translate(Vector2.right * (direction * speed * Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {

                float height = col.contacts[0].point.y - headPoint.position.y;

                if (height > 0)
                {
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    speed = 0f;
                    anim.SetTrigger(die);
                    boxCollider2D.enabled = false;
                    rig.bodyType = RigidbodyType2D.Kinematic;
                    Destroy(gameObject, 0.33f);
                }
                else {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

        }

    }
}
