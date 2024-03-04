using UnityEngine;

namespace Architecture.UI.Configs
{
    [CreateAssetMenu(menuName = "Configs/UI/PopupConfig")]
    class PopupConfig : ScriptableObject
    {
        [SerializeField]
        internal AbstractPopup[] PopupPrefabs = null!;
    }
}