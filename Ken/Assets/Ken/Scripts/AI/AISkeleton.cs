using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkeleton : AIStateBase
{
    protected Vector3 m_vSpawnPos;
    protected float m_fGuardRange;
    protected float m_fAttackRange;

    public override void Enter() { }
    public override void Exit() { }
    public override AIStateBase Execute() { return null; }

    public class Idle : AISkeleton
    {
        protected Vector3 m_vRPos;
        protected Vector3 m_vLPos;
        protected float m_fInterval;

        public Idle()
        {
            StateType = (int)EStateType.Idle;
            
        }

        public override void Enter()
        {
            m_fAttackRange = (Agent as Skeleton).GetAttribute().AttackRange;
            m_fGuardRange = ((Agent as Skeleton).GetAttribute() as EnemyAttribute).GuardRange;
            m_fInterval = 2;
            Debug.Log("SkeletonAI enter idle mode");
        }

        public override void Exit()
        {
            Debug.Log("SkeletonAI exit idle mode");
        }

        public override AIStateBase Execute()
        {
            Skeleton _sk = Agent as Skeleton;

            if(Character.ECharState.Dead == _sk.GetCharacterState())
            {
                return m_Machine.Transition((int)EStateType.Death);
            }

            Character _playerPawn = GameInstance.Instance.GetPlayerPawn();

            m_vRPos = (Agent as Skeleton).GetSpawnPosition() + 5 * Vector3.right;
            m_vLPos = (Agent as Skeleton).GetSpawnPosition() + 5 * Vector3.right * -1;

            float _dis = Vector3.Distance(_playerPawn.GetCharacterPosition(), _sk.GetCharacterPosition());

            if (_dis < (_sk.GetAttribute() as EnemyAttribute).AttackRange)
            {
                return m_Machine.Transition((int)EStateType.Attack);
            }

            if ( _dis < (_sk.GetAttribute() as EnemyAttribute).GuardRange)
            {
                return m_Machine.Transition((int)EStateType.Chase);
            }

            _sk.Move(0);
            return this;
        }
    }

    public class Chase : AISkeleton
    {
        public Chase()
        {
            StateType = (int)EStateType.Chase;
        }

        public override void Enter()
        {
            m_fAttackRange = (Agent as Skeleton).GetAttribute().AttackRange;
            m_fGuardRange = ((Agent as Skeleton).GetAttribute() as EnemyAttribute).GuardRange;
           // Debug.Log("SkeletonAI enter Chase mode");
        }

        public override void Exit()
        {
           // Debug.Log("SkeletonAI exit Chase mode");
        }

        public override AIStateBase Execute()
        {
            Skeleton _sk = Agent as Skeleton;

            if (Character.ECharState.Dead == _sk.GetCharacterState())
            {
                return m_Machine.Transition((int)EStateType.Death);
            }

            Character _playerPawn = GameInstance.Instance.GetPlayerPawn();

            float _dis = Vector3.Distance(_playerPawn.GetCharacterPosition(), _sk.GetCharacterPosition());
   
            if(_dis < (_sk.GetAttribute() as EnemyAttribute).AttackRange - 0.1f)
            {
                return m_Machine.Transition((int)EStateType.Attack);
            }

            if(_dis > (_sk.GetAttribute() as EnemyAttribute).GuardRange)
            {
                return m_Machine.Transition((int)EStateType.Idle);
            }

           (_sk.GetController() as AIController).MoveTo(_playerPawn.GetCharacterPosition());
           return this;
        }
    }

    public class Attack : AISkeleton
    {
        public Attack()
        {
            StateType = (int)EStateType.Attack;
        }

        public override void Enter()
        {
            m_fAttackRange = (Agent as Skeleton).GetAttribute().AttackRange;
            m_fGuardRange = ((Agent as Skeleton).GetAttribute() as EnemyAttribute).GuardRange;
           // Debug.Log("SkeletonAI enter Attack mode");
        }

        public override void Exit()
        {
          //  Debug.Log("SkeletonAI exit Attack mode");
        }

        public override AIStateBase Execute()
        {
            Skeleton _sk = Agent as Skeleton;

            if (Character.ECharState.Dead == _sk.GetCharacterState())
            {
                return m_Machine.Transition((int)EStateType.Death);
            }

            if (_sk.GetCharacterState() == Character.ECharState.Attacking)
            {
                return this;
            }

            Character _playerPawn = GameInstance.Instance.GetPlayerPawn();

            float _dis = Vector3.Distance(_playerPawn.GetCharacterPosition(), _sk.GetCharacterPosition());
            if(_dis > m_fGuardRange)
            {
                return m_Machine.Transition((int)EStateType.Idle);
            }

            if(_dis > m_fAttackRange)
            {
                return m_Machine.Transition((int)EStateType.Chase);
            }

            (_sk.GetController() as AIController).DoAttack();
            
            return this;          
        }
    }

    public class Death : AIStateBase
    {
        public Death()
        {
            StateType = (int)EStateType.Death;
        }

        public override void Enter()
        {

            // Debug.Log("SkeletonAI enter idle mode");
        }

        public override void Exit()
        {
            //Debug.Log("SkeletonAI exit idle mode");
        }

        public override AIStateBase Execute()
        {
            Skeleton _sk = Agent as Skeleton;

            _sk.Move(0);

            return this;
        }
    }
}
