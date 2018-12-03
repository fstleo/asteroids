using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.Entities
{
    public class PlayerBase : MonoBehaviour
    {
        [Inject] private IHitListener _baseHitListener;

        private void OnCollisionEnter2D(Collision2D other)
        {
            _baseHitListener.ProcessHit();
        }
    }
}