using UnityEngine;

namespace Platform
{
    public class FallingPlatform : MonoBehaviour
    {
        [SerializeField] private float fallingTime;
        private TargetJoint2D targetJoint;
        private BoxCollider2D boxColl;

        private void Start()
        {
            targetJoint = GetComponent<TargetJoint2D>();
            boxColl = GetComponent<BoxCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Invoke(nameof(Fall), fallingTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 7)
            {
                Destroy(gameObject);
            }
        }

        private void Fall()
        {
            targetJoint.enabled = false;
            boxColl.isTrigger = true;
        }
    }
}
