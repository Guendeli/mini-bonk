using System;
using UnityEngine;

namespace Code.Gameplay.Lifetime.Behaviours
{
    public class Experience : MonoBehaviour
    {
        [field: SerializeField] public int CurrentExperience { get; private set; }
        
        public event Action<int> OnXPChanged; 

        public void AddExperience(int amount)
        {
            CurrentExperience = Mathf.Clamp(CurrentExperience + amount, 0, Int32.MaxValue);
            OnXPChanged?.Invoke(CurrentExperience);
        }
        
    }
}