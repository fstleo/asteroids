using Game.Core.Player;
using Game.Core.Player.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.GameUI
{
	public class TopScoreLabel : MonoBehaviour 
	{

		[SerializeField]
		private TMPro.TMP_Text _scoreLabel;

		[Inject]
		private IScoreSource _scoreSource;

		private void OnEnable()
		{
			UpdateScoreLabel(_scoreSource.TopScores);
		}

		private void UpdateScoreLabel(int topScores)
		{
			_scoreLabel.text = $"Top score:{topScores}";
		}
	}
}
