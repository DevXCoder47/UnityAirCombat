using UnityEngine;

namespace NPC
{
    public class MoveState : State, IState
    {
        private readonly Movement _movement;
        

        public MoveState(Movement movement, StateMachine fsm, NPCController npc) : base(fsm, npc)
        {
            _movement = movement;
        }

        public void Enter()
        {
            _npc.StartCoroutine(ChangeStateRoutine());
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            switch (_movement) 
            {
                case Movement.Idle: _npc.MoveIdle(); break;
                case Movement.Accelerated: _npc.Accelerate(); break;
                case Movement.Delayed: _npc.Decelerate(); break;
            }

            _npc.HandleSpeed();
            _npc.MoveForward();
        }
    }
}
