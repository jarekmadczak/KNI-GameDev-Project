using UnityEngine;

namespace Architecture.Presentation.Data
{
    [CreateAssetMenu(menuName = "Data/Presentation/LevelData")]
    class LevelData : ScriptableObject
    {
        [SerializeField]
        internal int LevelNumber;
    }
}
