using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitedState : StateMachineBehaviour
{
    private float m_fSpeedAtten;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Character _char = GameInstance.Instance.GetPlayerPawn();
        _char.SetCharacterState(Character.ECharState.Hited);
        m_fSpeedAtten = _char.GetAttribute().MoveSpeedAtten;
        _char.SetMoveSpeedAtten(0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log(animator.avatar.name + ": " + GameInstance.Instance.GetPlayerPawn().GetCharacterState());
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameInstance.Instance.GetPlayerPawn().SetMoveSpeedAtten(m_fSpeedAtten);
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
