using Architecture.Presentation.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Architecture.Presentation.Views
{
    class LevelView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        LevelData _levelData;
        public void OnPointerClick(PointerEventData eventData)
        {
            PresentationViewModel.LevelClickHandler(_levelData);
        }
    }
}
