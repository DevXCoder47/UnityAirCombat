using UnityEngine;

namespace NPC 
{
    public class PitchState : State, IState
    {
        private readonly VerticalDirection _direction;

        public PitchState(VerticalDirection direction, StateMachine fsm, NPCController npc) : base(fsm, npc)
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
                case VerticalDirection.Up: _npc.PitchUp(); break;
                case VerticalDirection.Down: _npc.PitchDown(); break;
            }

            _npc.HandleSpeed();
            _npc.MoveForward();
        }
    }
}
