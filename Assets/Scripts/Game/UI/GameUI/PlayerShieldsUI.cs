using Game.Core.Player;
using Game.Core.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.UI.GameUI
{
    public class PlayerShieldsUI : MonoBehaviour, IInitializable 
    {

        [Inject]
        private ILivesHandler _liveController;

        [SerializeField]
        private Transform _shieldsHandler;
        private GameObject [] _shields;
        
        [SerializeField]
        private GameObject _warningSign;

        public void Initialize()
        {
            _liveController.OnLiveAmountChange += SetActiveShields;
            
            InitShieldsArray();

            SetActiveShields(_liveController.LiveCount);            
        }

        private void InitShieldsArray()
        {
            _shields = new GameObject[_liveController.LiveCount];
            
            var prototype = _shieldsHandler.GetChild(0);
            
            for (int i = 0; i < _shields.Length; i++)
            {
                _shields[i] = Instantiate(prototype.gameObject, _shieldsHandler);                
            }
            Destroy(prototype.gameObject);
        }

        public void SetActiveShields(int amount)
        {
            for (int i = 0; i < _shields.Length; i++)
            {
                _shields[i].SetActive(i < amount);
            }
            _warningSign.SetActive(amount == 0);
        }
    }
}