using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.UI.MenuState.View.Implementation
{
	public class MainMenuView : MenuStateView 
	{
	
		public void OnExitButtonClick()
		{
			Application.Quit();
		}
	
	
		public void OnStartGameButtonClick()
		{
			SetState(UIState.Game);
			SceneManager.LoadScene(1);
		}
	}
}
