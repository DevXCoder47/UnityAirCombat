using UnityEngine;

namespace NPC
{
    public class YawState : State, IState
    {
        private readonly HorizontalDirection _direction;

        public YawState(HorizontalDirection direction, StateMachine fsm,  NPCController npc) : base(fsm, npc) 
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
            switch (_direction)
            {
                case HorizontalDirection.Left: _npc.YawLeft(); break;
                case HorizontalDirection.Right: _npc.YawRight(); break;
            }

            _npc.HandleSpeed();
            _npc.MoveForward();
        }
    }
}
