using UnityEngine;

namespace NPC 
{
    public class RollState : State, IState
    {
        private readonly HorizontalDirection _direction;

        public RollState(HorizontalDirection direction, StateMachine fsm,  NPCController npc) : base(fsm, npc) 
        {
            _direction = direction;
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
            switch(_direction)
            {
                case HorizontalDirection.Left: _npc.RollLeft(); break;
                case HorizontalDirection .Right: _npc.RollRight(); break;
            }

            _npc.HandleSpeed();
            _npc.MoveForward();
        }
    }
}
