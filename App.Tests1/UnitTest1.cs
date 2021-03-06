using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Xunit;

namespace App.Tests1
{
    public class UnitTest1
    {
        [Fact]
        public void StartBackgroundProcess()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                if (Directory.Exists(Path.Combine(dir.FullName, "BackgroundApp1")))
                {
                    break;
                }

                dir = dir.Parent;
            }
            
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run -p BackgroundApp1/BackgroundApp1.csproj --no-build",
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = dir.FullName,
            });
            Console.WriteLine("Started PID = " + process.Id);
            Thread.Sleep(TimeSpan.FromSeconds(2)); // wait a little for dotnet-run to at least start the background process
        }
    }
}