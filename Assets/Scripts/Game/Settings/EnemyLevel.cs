using System;
using UnityEngine;

namespace Game.Settings
{
	[Serializable]
	public class EnemyLevel
	{
        
		#region Serialized fields
		[SerializeField]
		private int _startFromScore;

		[SerializeField]
		private float _projectileSpeed;
		
		[SerializeField]
		private int _scoreForKill;
        
		#endregion

		#region Public properties   

		public int ScoreForKill => _scoreForKill;

		public float ProjectileSpeed => _projectileSpeed;

		public int StartFromScore => _startFromScore;
		
		#endregion
	}
}
