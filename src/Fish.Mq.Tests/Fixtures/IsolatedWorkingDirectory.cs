using System;
using System.IO;

namespace Fish.Mq.Tests.Fixtures
{
    public class IsolatedWorkingDirectory : IDisposable
    {
        public string Path { get; private set; }

        public IsolatedWorkingDirectory()
        {
            Path = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "App_Data", Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(Path);
        }

        public void Dispose()
        {
            Directory.Delete(Path, true);
        }
    }
}