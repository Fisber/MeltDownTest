
using SO;
using UnityEngine;

public class PlayerAnimationLocker : StateMachineBehaviour
{
    [SerializeField] private AnimationLocker AnimationLocker;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Jump"))
        {
            AnimationLocker.IsJumping = true;
        }
        if (stateInfo.IsName("Crunch"))
        {
            AnimationLocker.IsCrunch = true;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex
    )
    {
        AnimationLocker.IsJumping = false;
        AnimationLocker.IsCrunch = false;
    }
}