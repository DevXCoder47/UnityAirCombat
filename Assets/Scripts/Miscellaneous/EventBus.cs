using System;
using UnityEngine;

namespace Miscellaneous
{
    public static class EventBus
    {
        public static event Action OnMainPropellerReady;

        public static void RaiseMainPropellerReady() => OnMainPropellerReady?.Invoke();
    }
}
