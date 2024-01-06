using Naninovel;

namespace Nani.Services
{
    [InitializeAtRuntime]
    public class MemoryGameService : IEngineService
    {
        public UniTask InitializeServiceAsync()
        {
            return UniTask.CompletedTask;
        }
    
        public void ResetService()
        {
            
        }
    
        public void DestroyService()
        {
            
        }
    }
}