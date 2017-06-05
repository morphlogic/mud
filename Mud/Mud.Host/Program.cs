using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mud.Engine;
using Serilog;
using Topshelf;
using Topshelf.Ninject;

namespace Mud.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            HostFactory.Run(x =>
            {
                x.UseNinject();
                x.UseSerilog();

                x.Service<MudServer>(
                    sc =>
                    {
                        sc.ConstructUsingNinject();

                        sc.WhenStarted((s, h) =>
                        {
                            s.Start();

                            return true;
                        });

                        sc.WhenStopped((s, h) =>
                        {
                            s.Stop();

                            return true;
                        });
                    });
            });
        }
    }
}
