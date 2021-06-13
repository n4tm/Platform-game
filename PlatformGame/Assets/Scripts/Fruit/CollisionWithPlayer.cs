using UnityEngine;

namespace Fruit
{
    public class CollisionWithPlayer : MonoBehaviour
    {
        private CircleCollider2D circleColl;
        private SpriteRenderer spriteRend;
        public GameObject collected;
        public int score;
        private void Start()
        {
            circleColl = GetComponent<CircleCollider2D>();
            spriteRend = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                circleColl.enabled = false;
                spriteRend.enabled = false;
                collected.SetActive(true);
                GameController.Score.instance.totalScore += score;
                GameController.Score.instance.UpdateScoreText();
                Destroy(gameObject, 0.25f);
            }
        }
    }
}
