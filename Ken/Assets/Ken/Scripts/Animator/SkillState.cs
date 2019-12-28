using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameInstance.Instance.GetPlayerPawn().SetCharacterState(Character.ECharState.Skill);
        GameInstance.Instance.GetPlayerPawn().SetMoveSpeedAtten(0);
        GameInstance.Instance.GetPlayerPawn().Move(0);
        GameInstance.Instance.GetPlayerController().DeactivateInput();
        GameTools.Instance.SetTimeScale(0.5f);
        GameTools.Instance.TimerForSeconds(0.1f, () =>
         {
             GameTools.Instance.SetTimeScale(1);
         });
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameInstance.Instance.GetPlayerController().ActivateInput();
        GameInstance.Instance.GetPlayerPawn().SetMoveSpeedAtten(1f);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
