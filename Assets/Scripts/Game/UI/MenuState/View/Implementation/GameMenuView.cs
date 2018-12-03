namespace Game.UI.MenuState.View.Implementation
{
	public class GameMenuView : MenuStateView 
	{

		public void OnPauseButtonClick()
		{
			SetState(UIState.Pause);
		}

	}
}
