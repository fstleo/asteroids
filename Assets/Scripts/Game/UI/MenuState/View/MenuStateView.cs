using UnityEngine;
using Zenject;

namespace Game.UI.MenuState.View
{
    public abstract class MenuStateView : MonoBehaviour, IInitializable, ILateDisposable
    {

        [SerializeField]
        private UIState _state;

        private GameObject _gameObject;

        protected bool IsActive;

        public virtual void Initialize()
        {
            _gameObject = gameObject;
            MenuState.OnMenuStateChange += CheckActivity;
            CheckActivity(MenuState.CurrentState);
        }

        public void LateDispose()
        {        
            MenuState.OnMenuStateChange -= CheckActivity;
        }

        protected void SetState(UIState state)
        {
            MenuState.CurrentState = state;
        }
    
        private void CheckActivity(UIState obj)
        {
            SetActive(obj == _state);
        }

        protected virtual void SetActive(bool active)
        {
            IsActive = active;
            _gameObject.SetActive(active);
        }
    
    }
}
