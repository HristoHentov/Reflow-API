using Logger.Contract;

namespace ReflowCore.Controllers
{
    public class DirectoryStructureController : IReflowController
    {
        private ILog _log;


        public DirectoryStructureController()
        {
            ///TODO: Handle log
        }
        public DirectoryStructureController(ILog log)
        {
            _log = log;
        }
        public void Initialize()
        {
            
        }
    }
}
