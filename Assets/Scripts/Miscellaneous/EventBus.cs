using System;
using UnityEngine;

namespace Miscellaneous
{
    public static class EventBus
    {
        public static event Action OnMainPropellerReady;
        public static event Action<float> OnHealthChanged;

        public static void RaiseMainPropellerReady() => OnMainPropellerReady?.Invoke();
        public static void RaiseHealthChanged(float currentHealth) => OnHealthChanged?.Invoke(currentHealth);
    }
}
