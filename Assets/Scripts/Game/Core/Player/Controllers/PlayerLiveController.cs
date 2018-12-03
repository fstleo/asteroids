using System;
using Game.Core.Interfaces;
using Game.Core.Player.Interfaces;
using Game.Settings;

namespace Game.Core.Player.Controllers
{
    public class PlayerLiveController : ILivesHandler, IHitListener
    {
        private int _liveCount;

        public PlayerLiveController(PlayerSettings settings)
        {
            LiveCount = settings.Lives;
        }

        public void ProcessHit()
        {
            LiveCount--;
            if (LiveCount < 0) OnDie?.Invoke();
        }

        public event Action OnDie;
        public event Action<int> OnLiveAmountChange;

        public int LiveCount
        {
            get { return _liveCount; }
            private set
            {
                _liveCount = value;
                OnLiveAmountChange?.Invoke(_liveCount);
            }
        }
    }
}