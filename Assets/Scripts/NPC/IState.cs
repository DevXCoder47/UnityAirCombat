using UnityEngine;

namespace NPC
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}

