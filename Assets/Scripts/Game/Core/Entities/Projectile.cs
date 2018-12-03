using System;
using Game.Core.Entities.Interfaces;
using UnityEngine;

namespace Game.Core.Entities
{
    public class Projectile : MonoBehaviour, IMove, IProjectile
    {
        private GameObject _gameObject;
        private Rigidbody2D _rigidbody;
        private float _speed;

        private Transform _transform;
        private Vector2 _velocity;
        public event Action OnReachTarget;


        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public Vector2 Position { get; set; }
        public Vector2 Target { get; set; }

        public void Shot()
        {
            _gameObject.SetActive(true);
            _transform.position = Position;
            _velocity = (Target - _rigidbody.position).normalized * _speed;
            _transform.right = Target - _rigidbody.position;
        }

        private void Awake()
        {
            _transform = transform;
            _gameObject = gameObject;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _velocity * Time.fixedDeltaTime);
            if ((_rigidbody.position - Target).sqrMagnitude < 0.1f) OnReachTarget?.Invoke();
        }
    }
}