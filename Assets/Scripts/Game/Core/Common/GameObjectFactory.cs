using UnityEngine;
using Zenject;

namespace Game.Core.Common
{
    public class GameObjectFactory : IFactory<GameObject>
    {
        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public GameObjectFactory(DiContainer container, GameObject prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public GameObject Create()
        {
            return _container.InstantiatePrefab(_prefab);
        }
    }
}