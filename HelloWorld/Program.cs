using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace HelloWorld
{
    internal static class Program
    {

        private static void Main()
        {
            try
            {
             
                ActorRuntime.RegisterActorAsync<HelloWorld>(
                   (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
