using UnityEngine;

namespace NPC
{
    public static class NPCScenario
    {
        private static int choice;

        public static IState GetRandomState(NPCController npc, StateMachine fsm)
        {
            if (npc.IsTooLow())
            {
                return new PitchState(VerticalDirection.Up, fsm, npc);
            }

            if (npc.IsNearGround())
            {
                choice = Random.Range(1, 4);

                switch (choice)
                {
                    case 1: return new MoveState(GetRandomMovement(), fsm, npc);
                    case 2: return new PitchState(VerticalDirection.Up, fsm, npc);
                    case 3: return new YawState(GetRandomHorizontalDirection(), fsm, npc);
                }
            }

            choice = Random.Range(1, 5);

            switch (choice)
            {
                case 1: return new MoveState(GetRandomMovement(), fsm, npc);
                case 2: return new PitchState(GetRandomVerticalDirection(), fsm, npc);
                case 3: return new RollState(GetRandomHorizontalDirection(), fsm, npc);
                case 4: return new YawState(GetRandomHorizontalDirection(), fsm, npc);
            }

            return null;
        }

        private static Movement GetRandomMovement()
        {
            var values = System.Enum.GetValues(typeof(Movement));
            return (Movement)values.GetValue(Random.Range(0, values.Length));
        }

        private static VerticalDirection GetRandomVerticalDirection()
        {
            var values = System.Enum.GetValues(typeof(VerticalDirection));
            return (VerticalDirection)values.GetValue(Random.Range(0, values.Length));
        }

        private static HorizontalDirection GetRandomHorizontalDirection()
        {
            var values = System.Enum.GetValues(typeof(HorizontalDirection));
            return (HorizontalDirection)values.GetValue(Random.Range(0, values.Length));
        }
    }
}
