using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.UI.MenuState.View.Implementation
{
	public class GamePauseMenuView : MenuStateView 
	{

		public void OnReturnToGameButtonClick()
		{
			SetState(UIState.Game);
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
