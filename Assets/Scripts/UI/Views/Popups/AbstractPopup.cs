using Architecture.Common;
using Architecture.UI.Systems;
using UnityEngine;

namespace Architecture.UI
{
    [DisallowMultipleComponent]
    abstract class AbstractPopup: MonoBehaviour
    {
        internal readonly PopupType Type;

        protected AbstractPopup(PopupType popupType) => Type = popupType;

        internal virtual void Initialize()
        {
            gameObject.SetActive(true);
            PopupSystem.CurrentPopup = this;
        }

        internal virtual void Close()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            InputSystem.PopupInputs.DisableInput();
            PopupSystem.CurrentPopup = null;
        }
    }
}