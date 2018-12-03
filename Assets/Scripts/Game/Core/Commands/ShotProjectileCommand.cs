using System;
using Game.Core.Entities;
using Game.Core.Interfaces;

namespace Game.Core.Commands
{
    public class ShotProjectileCommand : ICommand
    {
        public IProjectile Projectile { get; set; }
        public event Action OnExecute;

        public void Execute()
        {
            Projectile.Shot();
            OnExecute?.Invoke();
        }
    }
}