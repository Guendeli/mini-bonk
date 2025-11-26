using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Characters.Heroes.Configs
{
    [CreateAssetMenu(fileName = "ProgressionConfig", menuName = Constants.GameName + "/Configs/Progression")]
    public class ProgressionConfig : ScriptableObject
    {
        public ProgressionTable XPTable;
    }

    [System.Serializable]
    public struct ProgressionTable
    {
        public List<int> ExperiencePerLevel;
    }
}