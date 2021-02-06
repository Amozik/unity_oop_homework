using System.Collections.Generic;
using System.Linq;
using General.Interfaces;
using UnityEngine;

namespace General.Controllers
{
    internal sealed class BonusInitialization : IInitialization
    {
        private List<InteractiveObject> _bonuses;
        
        public BonusInitialization()
        {
            _bonuses = Object.FindObjectsOfType<InteractiveObject>().ToList();
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