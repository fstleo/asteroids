using System.Collections.Generic;
using Game.Core.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Core.Common
{
    public class TimedCommandExecutor : ICommandExecutor, IFixedTickable
    {
        private readonly float _cooldown;

        private float _currentCooldown;

        private readonly Queue<ICommand> _spawnQueue = new Queue<ICommand>(20);

        public TimedCommandExecutor(float cooldown)
        {
            _cooldown = cooldown;
        }

        public void Execute(ICommand command)
        {
            _spawnQueue.Enqueue(command);
        }

        public void FixedTick()
        {
            if (_currentCooldown > 0)
            {
                _currentCooldown -= Time.deltaTime;
            }
            else
            {
                if (_spawnQueue.Count == 0) return;

                _spawnQueue.Dequeue().Execute();
                _currentCooldown = _cooldown;
            }
        }
    }
}