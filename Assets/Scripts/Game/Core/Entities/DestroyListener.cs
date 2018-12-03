using System;
using Game.Core.Entities.Interfaces;
using UnityEngine;

namespace Game.Core.Entities
{
    public class DestroyListener : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroy;
        public void Destroy()
        {
            OnDestroy?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy();
        }
    }
}