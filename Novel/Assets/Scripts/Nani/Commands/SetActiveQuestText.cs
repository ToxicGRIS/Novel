using DTT.MinigameMemory;
using Nani.UI;
using Naninovel;
using UnityEngine;

namespace Nani.Commands
{
    public class SetActiveQuestText : Command
    {
        [RequiredParameter]
        public StringParameter key;
        
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            var uiManager = Engine.GetService<IUIManager>();
            var activeQuestUI = uiManager.GetUI<ActiveQuestUI>();
            activeQuestUI.SetText(key, "Quests");
            return UniTask.CompletedTask;
        }
    }
}