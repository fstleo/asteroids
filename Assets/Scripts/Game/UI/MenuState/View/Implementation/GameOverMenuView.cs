using Game.Core.Player.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.UI.MenuState.View.Implementation
{
	public class GameOverMenuView : MenuStateView
	{
		[Inject] 
		private ILivesHandler _livesHandler;
		
		public override void Initialize()
		{
			base.Initialize();
			_livesHandler.OnDie += EnableGameOver;
		}

		private void EnableGameOver()
		{
			SetState(UIState.GameOver);
		}

		public void OnExitButtonClick()
		{
			SetState(UIState.MainMenu);
			SceneManager.LoadScene(0);
		}
	
	
		public void OnRestartButtonClick()
		{
			SetState(UIState.Game);
			SceneManager.LoadScene(1);
		}

		protected override void SetActive(bool active)
		{
			if (IsActive == active)
			{
				return;
			}
			Time.timeScale = active ? 0 : 1;		
			base.SetActive(active);
		}
	}
}
