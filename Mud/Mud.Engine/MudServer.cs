using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Logging;

namespace Mud.Engine
{
    public class MudServer
    {
        private readonly ILogger _logger;

        public MudServer(ILogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            _logger.Info("MudServer.Start()");
        }

        public void Stop()
        {
            _logger.Info("MudServer.Stop()");
        }
    }
}
