using UnityEngine;

namespace Dan
{
    public class ConfettiSummoner : MonoBehaviour
    {
        [SerializeField] private GameObject confettiPrefab;
        
        public void SummonConfetti()
        {
            Instantiate(confettiPrefab);
        }
    }
}
