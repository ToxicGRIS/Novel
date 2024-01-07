using DTT.MinigameMemory;
using Nani.Services;
using Naninovel;
using UnityEngine;

namespace Nani.Commands
{
    public class StartMemoryGame : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            // Debug.Log("___StartMemoryGame");

            var memoryGameService = Engine.GetService<MemoryGameService>();
            return memoryGameService.StartGame();
        }
    }
}