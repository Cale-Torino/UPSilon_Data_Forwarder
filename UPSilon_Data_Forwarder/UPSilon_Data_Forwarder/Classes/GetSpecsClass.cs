using System.Reflection;
using System.Text;

namespace UPSilon_Data_Forwarder
{
    internal class GetSpecsClass
    {
        internal static string GetSpecs()
        {
            StringBuilder s = new StringBuilder();
            s.Clear();
            s.AppendLine("--------------------------------------------");
            s.AppendLine("==== Get PC Specs ==========================");
            s.AppendLine("Get All The PC Specs");
            s.AppendLine("--------------------------------------------");
            s.AppendLine($"UserName: {Environment.UserName}");
            s.AppendLine($"MachineName: {Environment.MachineName}");
            s.AppendLine($"UserDomainName: {Environment.UserDomainName}");
            s.AppendLine($"ProcessorCount: {Environment.ProcessorCount}");
            s.AppendLine($"CurrentDirectory: {Environment.CurrentDirectory}");
            s.AppendLine($"Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}");
            s.AppendLine($"OSVersion: {Environment.OSVersion}");
            s.AppendLine($"SystemDirectory: {Environment.SystemDirectory}");
            s.AppendLine($"TickCount: {Environment.TickCount}");
            s.AppendLine($"Version: {Environment.Version}");
            s.AppendLine($"WorkingSet: {Environment.WorkingSet}");
            s.AppendLine($"App Version: {Assembly.GetExecutingAssembly().GetName().Version}");
            s.AppendLine($"App Name: {Assembly.GetExecutingAssembly().GetName().Name}");
            s.AppendLine($"App FullName: {Assembly.GetExecutingAssembly().GetName().FullName}");
            s.AppendLine("--------------------------------------------");
            return s.ToString();
        }
    }
}
