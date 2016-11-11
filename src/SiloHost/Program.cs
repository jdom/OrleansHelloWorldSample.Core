using System;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace OrleansSiloHost
{
    public class Program
    {
        private static OrleansHostWrapper hostWrapper;

        public static int Main(string[] args)
        {
            int exitCode = StartSilo(args);

            Console.WriteLine("Press Enter to terminate...");
            Console.ReadLine();

            exitCode += ShutdownSilo();

            //either StartSilo or ShutdownSilo failed would result on a non-zero exit code. 
            return exitCode;
        }


        private static int StartSilo(string[] args)
        {
            // define the cluster configuration
            var config = ClusterConfiguration.LocalhostPrimarySilo();
            config.Globals.DataConnectionString = "Your azure connection string";
            config.Globals.LivenessType = GlobalConfiguration.LivenessProviderType.AzureTable;
            config.Globals.DeploymentId = "DeployemtnId";
            config.AddAzureTableStorageProvider("AzureStore");
            hostWrapper = new OrleansHostWrapper(config, args);
            return hostWrapper.Run();
        }

        private static int ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                return hostWrapper.Stop();
            }
            return 0;
        }
    }
}
