using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/Player")]
    public class PlayerSettings : ScriptableObject
    {
        #region Serialized fields

        [SerializeField] private Vector2 _spawnerViewPortPosition;

        [SerializeField] private float _cooldown;

        [SerializeField] private float _projectileSpeed;

        [SerializeField] private GameObject _projectile;

        [SerializeField] private int _lives;

        #endregion

        #region Public properties

        public Vector2 SpawnerViewPortPosition => _spawnerViewPortPosition;

        public float Cooldown => _cooldown;

        public int Lives => _lives;

        public float ProjectileSpeed => _projectileSpeed;

        public GameObject Projectile => _projectile;

        #endregion
    }
}