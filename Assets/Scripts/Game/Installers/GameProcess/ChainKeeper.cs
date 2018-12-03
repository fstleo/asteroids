using UnityEngine;
using Zenject;

namespace Game.Installers.GameProcess
{
    public class ChainKeeper<T> : IFactory<int, T>
    {
        private readonly ChainKeeper<T> _next;
        private readonly int _scoreNeeded;
        private readonly T _storedObject;

        public ChainKeeper(int scoreNeeded, T storedObject, ChainKeeper<T> next = null)
        {
            _scoreNeeded = scoreNeeded;
            _storedObject = storedObject;
            _next = next;
        }

        public T Create(int param)
        {
            if (param < _scoreNeeded && _next != null) return _next.Create(param);

            return _storedObject;
        }
    }
}