using Player;
using UnityEngine;

namespace Animation
{
    public class PlayerAnimationTransition : MonoBehaviour
    {
        [SerializeField] private PlayerMove playerMoveScript;
        private Animator playerAnimator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        

        private void Start()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            var velocity = playerMoveScript.horizontalMove;
            playerAnimator.SetFloat(Speed,velocity);
            playerAnimator.SetBool(Jump, !playerMoveScript.canJump);
        }
    }
}
