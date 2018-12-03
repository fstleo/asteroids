using Game.Core.Player;
using Game.Core.Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.UI.GameUI
{
	public class ScoreLabel : MonoBehaviour, IInitializable, ILateDisposable
	{
		[SerializeField]
		private TMPro.TMP_Text _scoreLabel;

		[Inject]
		private IScoreSource _scoreSource;

		public void Initialize()
		{			
			_scoreSource.OnScoreChange += UpdateScoreLabel;
		}
		
		private void OnEnable()
		{
			UpdateScoreLabel(_scoreSource.Scores);
		}

		private void UpdateScoreLabel(int currentScores)
		{
			_scoreLabel.text = $"Score:{currentScores}";
		}

		public void LateDispose()
		{
			_scoreSource.OnScoreChange -= UpdateScoreLabel;
		}
	}
}
