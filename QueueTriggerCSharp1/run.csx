#r "Microsoft.WindowsAzure.Storage"

using Microsoft.WindowsAzure.Storage.Queue;
using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

private static string key = TelemetryConfiguration.Active.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);
private static TelemetryClient telemetry = new TelemetryClient() { InstrumentationKey = key };

/*
public static void Run(string myQueueItem, TraceWriter log)
{
    log.Info($"C# Queue trigger function processed: {myQueueItem}");
    telemetry.TrackTrace($"mytrace: {myQueueItem}");
}
*/
 
public static void Run(CloudQueueMessage myQueueItem, 
    DateTimeOffset expirationTime, 
    DateTimeOffset insertionTime, 
    DateTimeOffset nextVisibleTime,
    string queueTrigger,
    string id,
    string popReceipt,
    int dequeueCount,
    TraceWriter log)
{
    log.Info($"C# Queue trigger function processed: {myQueueItem.AsString}\n" +
        $"queueTrigger={queueTrigger}\n" +
        $"expirationTime={expirationTime}\n" +
        $"insertionTime={insertionTime}\n" +
        $"nextVisibleTime={nextVisibleTime}\n" +
        $"id={id}\n" +
        $"popReceipt={popReceipt}\n" + 
        $"dequeueCount={dequeueCount}");
        telemetry.TrackTrace($"mytrace dequeueCount: {dequeueCount}");

}
