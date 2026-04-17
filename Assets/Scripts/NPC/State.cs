using System.Collections;
using UnityEngine;

namespace NPC
{
    public class State
    {
        protected readonly StateMachine _fsm;
        protected readonly NPCController _npc;

        public State(StateMachine fsm, NPCController npc)
        {
            _fsm = fsm;
            _npc = npc;
        }

        protected IEnumerator ChangeStateRoutine()
        {
            float delay = Random.Range(0f, 3f);
            yield return new WaitForSeconds(delay);
            _fsm.SetState(NPCScenario.GetRandomState(_npc, _fsm));
        }
    }
}
