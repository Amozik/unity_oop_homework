using System.Collections.Generic;
using System.Linq;
using General.Interfaces;
using UnityEngine;

namespace General.Controllers
{
    internal sealed class BonusInitialization : IInitialization
    {
        private CompositeEffect _effect;
        private List<InteractiveObject> _bonuses;
        
        public BonusInitialization()
        {
            _bonuses = Object.FindObjectsOfType<InteractiveObject>().ToList();
            _effect = new CompositeEffect(_bonuses);
        }

        public IEffect GetEffectBonuses()
        {
            return _effect;
        }

        public IEnumerable<InteractiveObject> GetBonuses()
        {
            return _bonuses;
        }

        public void Initialization()
        {

        }
    }
}