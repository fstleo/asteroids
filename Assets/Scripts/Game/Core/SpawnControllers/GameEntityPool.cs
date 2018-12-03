using System;
using System.Collections.Generic;
using Game.Core.Entities.Interfaces;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Core.SpawnControllers
{
    public class GameEntityPool : IMemoryPool<GameObject>
    {
        private readonly HashSet<GameObject> _activeItems = new HashSet<GameObject>();
        private readonly IFactory<GameObject> _factory;
        private readonly Transform _handler;
        private readonly Queue<GameObject> _queue;

        public GameEntityPool(IFactory<GameObject> factory, int size)
        {
            _factory = factory;
            _handler = new GameObject(ItemType.Name).transform;
            _queue = new Queue<GameObject>(size);
            ExpandBy(size);
        }

        public void Despawn(GameObject item)
        {
            item.SetActive(false);
            item.transform.SetParent(_handler);
            _queue.Enqueue(item);
        }

        public GameObject Spawn()
        {
            if (NumInactive == 0) ExpandBy(1);
            var item = _queue.Dequeue();
            item.transform.SetParent(null);
            _activeItems.Add(item);
            return item;
        }

        public int NumTotal => _queue.Count + _activeItems.Count;
        public int NumActive => _activeItems.Count;
        public int NumInactive => _queue.Count;
        public Type ItemType => typeof(GameObject);

        public void Resize(int desiredPoolSize)
        {
            if (desiredPoolSize > NumTotal)
                ExpandBy(desiredPoolSize - NumTotal);
            else
                ShrinkBy(NumTotal - desiredPoolSize);
        }

        public void Clear()
        {
            ShrinkBy(NumInactive);
        }

        public void ExpandBy(int numToAdd)
        {
            for (var i = 0; i < numToAdd; i++) CreateNewItem();
        }

        public void ShrinkBy(int numToRemove)
        {
            for (var i = 0; i < numToRemove; i++) Object.Destroy(_queue.Dequeue().gameObject);
        }

        public void Despawn(object obj)
        {
            var o = obj as GameObject;
            if (o != null) Despawn(o);
        }

        private void CreateNewItem()
        {
            var item = _factory.Create();
            item.GetComponent<IDestroyable>().OnDestroy += () => Despawn(item);
            Despawn(item);
        }
    }
}