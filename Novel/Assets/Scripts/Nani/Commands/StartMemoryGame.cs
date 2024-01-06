using DTT.MinigameMemory;
using Naninovel;
using UnityEngine;

namespace Nani.Commands
{
    public class StartMemoryGame : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Debug.Log("___StartMemoryGame");
            var memoryGameManager = Object.FindObjectOfType<MemoryGameManager>();
            var memoryGameSettings = Resources.Load<MemoryGameSettings>("MemoryGameSettings");
            // memoryGameManager.Finish += results => { };
            memoryGameManager.StartGame(memoryGameSettings);
            return UniTask.CompletedTask;
        }
    }
}