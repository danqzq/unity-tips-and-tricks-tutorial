using UnityEngine;
using UnityEngine.Events;

namespace Dan
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CheckPoint : MonoBehaviour, ITriggerable
    {
        [SerializeField] private UnityEvent OnTrigger;

        private bool _hasBeenTriggered;
        
        public void OnTriggered()
        {
            if (_hasBeenTriggered) return;
            OnTrigger?.Invoke();
            _hasBeenTriggered = true;
        }
    }
}
