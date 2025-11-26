 using Code.Gameplay.Lifetime.Behaviours;
using UnityEngine;

namespace Code.Gameplay.PickUps.Behaviours
{
	[RequireComponent(typeof(PickUp))]
	public class HealOnPickUp : MonoBehaviour
	{
		[SerializeField] private float _healAmount; // TODO - Wouldn't it be better to balance if this value came from a scriptable objects instead of Prefab
		
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
			if (pickUpper.TryGetComponent(out Health health))
			{
				health.Heal(_healAmount);
			}
		}
	}
}