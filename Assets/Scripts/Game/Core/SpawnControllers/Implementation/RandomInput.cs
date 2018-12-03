using System;
using Game.Core.Interfaces;
using Game.Settings;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Core.SpawnControllers.Implementation
{
    public class RandomInput : ISpawnInput, IFixedTickable
    {
        private readonly float _magnitude;
        private readonly Transform _playerOrigin;

        private readonly EnemySettings _settings;

        private float _currentCreateCooldown;

        public RandomInput(EnemySettings settings, Transform playerOrigin, Camera camera)
        {
            _settings = settings;
            _playerOrigin = playerOrigin;

            _currentCreateCooldown = _settings.Cooldown;
            _magnitude = (camera.ViewportToWorldPoint(new Vector3(-0.1f, -0.1f)) - playerOrigin.position).magnitude;
        }

        public void FixedTick()
        {
            if (_currentCreateCooldown > 0)
            {
                _currentCreateCooldown -= Time.fixedDeltaTime;
                return;
            }

            OnInput?.Invoke(CalculateOrigin(), _playerOrigin.position);
            _currentCreateCooldown = _settings.Cooldown;
        }

        public event Action<Vector2, Vector2> OnInput;

        private Vector3 CalculateOrigin()
        {
            var pos = _playerOrigin.position +
                      Quaternion.Euler(0, 0, Random.Range(-_settings.SpawnMaxAngle, _settings.SpawnMaxAngle)) *
                      _playerOrigin.up * _magnitude;
            return pos;
        }
    }
}