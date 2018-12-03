using UnityEngine;

namespace Game.Settings.View
{
	
	[CreateAssetMenu(fileName = "ProjectileViewSettings", menuName = "Settings/View/Projectile View")]
	public class ProjectileViewSettings : ScriptableObject
	{
		
		#region Serialized fields
		
		[SerializeField]
		private GameObject _viewPrefab;
		
		[SerializeField]
		private GameObject _destroyEffect;
		
		#endregion

		#region Public properties

		public GameObject ViewPrefab => _viewPrefab;

		public GameObject DestroyEffect => _destroyEffect;

		#endregion
	}
}