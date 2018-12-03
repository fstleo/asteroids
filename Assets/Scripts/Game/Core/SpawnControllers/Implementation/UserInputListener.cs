using System;
using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.SpawnControllers.Implementation
{
    public class UserInputListener : MonoBehaviour, ISpawnInput
    {
        [Inject] private Camera _playerCamera;

        [Inject] private Transform _playerPlaceholder;

        public event Action<Vector2, Vector2> OnInput;

        public void OnMouseDown()
        {
            var target = _playerCamera.ScreenToWorldPoint(Input.mousePosition);
            OnInput?.Invoke(_playerPlaceholder.position, target);
        }
    }
}