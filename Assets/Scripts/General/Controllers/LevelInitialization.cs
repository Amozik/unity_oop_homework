using General.Interfaces;
using UnityEngine;

namespace General.Controllers
{
    internal sealed class LevelInitialization : IInitialization
    {
        private LevelConfig _config;
        
        public LevelInitialization(LevelConfig config)
        {
            _config = config;
            Object.Instantiate(_config.prefab);
        }
        
        
        public void Initialization()
        {
            
        }
    }
}