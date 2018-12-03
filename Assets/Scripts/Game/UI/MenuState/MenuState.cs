using System;

namespace Game.UI.MenuState
{
    internal static class MenuState
    {
        internal static event Action<UIState> OnMenuStateChange;

        private static UIState _currentState;

        internal static UIState CurrentState
        {
            get { return _currentState; }
            set
            {
                if (_currentState == value)
                {
                    return;
                }
                _currentState = value;
                OnMenuStateChange?.Invoke(_currentState);    
            }
        }


    }
}