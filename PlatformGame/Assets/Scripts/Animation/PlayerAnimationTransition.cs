using Player;
using UnityEngine;

namespace Animation
{
    public class PlayerAnimationTransition : MonoBehaviour
    {
        [SerializeField] private PlayerMove playerMoveScript;
        private Animator playerAnimator;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Jump = Animator.StringToHash("Jump");
        

        private void Start()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            var velocity = playerMoveScript.horizontalMove;
            if (velocity < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (velocity > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            playerAnimator.SetBool(Walk,playerMoveScript.horizontalMove != 0);
            playerAnimator.SetBool(Jump, playerMoveScript.isJumping);
        }
    }
}
