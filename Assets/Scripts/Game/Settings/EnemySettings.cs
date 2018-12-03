using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/Enemy")]
    public class EnemySettings : ScriptableObject
    {
        #region Serialized fields

        [SerializeField] private float _spawnMaxAngle;

        [SerializeField] private float _cooldown;

        [SerializeField] private EnemyLevel[] _levelsSettings;

        [SerializeField] private GameObject _prefab;

        #endregion

        #region Public properties               

        public float Cooldown => _cooldown;

        public EnemyLevel[] LevelsSettings => _levelsSettings;

        public float SpawnMaxAngle => _spawnMaxAngle;

        public GameObject Prefab => _prefab;

        #endregion
    }
}