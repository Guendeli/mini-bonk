using Code.Gameplay.Lifetime.Behaviours;
using UnityEngine;

namespace Code.Gameplay.PickUps.Behaviours
{
    [RequireComponent(typeof(PickUp))]
    public class GrantXPOnPickup : MonoBehaviour
    {
        [SerializeField] private int _xpAmount; // TODO - Wouldn't it be better to balance if this value came from a scriptable objects instead of Prefab
		
        private PickUp _pickUp;

        private void Awake()
        {
            _pickUp = GetComponent<PickUp>();
        }
        
        private void OnEnable()
        {
            _pickUp.OnPickUp += HandlePickup;
        }

        private void OnDisable()
        {
            _pickUp.OnPickUp -= HandlePickup;
        }

        private void HandlePickup(GameObject pickUpper)
        {
            if (pickUpper.TryGetComponent(out Experience xp))
            {
                xp.AddExperience(_xpAmount);
            }
        }
    }
}