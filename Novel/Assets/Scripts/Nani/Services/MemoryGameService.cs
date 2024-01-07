using DTT.MinigameMemory;
using Naninovel;
using UnityEngine;

namespace Nani.Services
{
    [InitializeAtRuntime]
    public class MemoryGameService : IEngineService
    {
        private MemoryGameManager _memoryGameManager;
        private MemoryGameSettings _memoryGameSettings;
        private bool _isFinished;

        public UniTask InitializeServiceAsync()
        {
            _memoryGameManager = Object.FindObjectOfType<MemoryGameManager>(true);
            _memoryGameSettings = Resources.Load<MemoryGameSettings>("MemoryGameSettings");
            _memoryGameManager.Finish += OnFinish;
            _memoryGameManager.gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }
    
        public void ResetService()
        {
            
        }
    
        public void DestroyService()
        {
            if (_memoryGameManager != null)
            {
                _memoryGameManager.Finish -= OnFinish;
                _memoryGameManager.gameObject.SetActive(false);
            }
        }

        public async UniTask StartGame()
        {
            _memoryGameManager.gameObject.SetActive(true);
            _memoryGameManager.StartGame(_memoryGameSettings);

            await UniTask.WaitUntil(() => _isFinished);
            _memoryGameManager.gameObject.SetActive(false);
        }

        private void OnFinish(MemoryGameResults memoryGameResults) => _isFinished = true;
    }
}