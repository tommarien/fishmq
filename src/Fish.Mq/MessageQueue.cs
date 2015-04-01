using System;
using System.IO;

namespace Fish.Mq
{
    public class MessageQueue
    {
        public string Path { get; private set; }
        public string Name { get; private set; }

        private DirectoryInfo WorkingDirectory { get; set; }

        public MessageQueue(string path, string name)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (name == null) throw new ArgumentNullException("name");

            Path = path;
            Name = name;

            GuardAgainstNotExistingPath();

            EnsureDirectoryExists();
        }

        private void GuardAgainstNotExistingPath()
        {
            if (!Directory.Exists(Path))
                throw new GoFishException("The root path for a message queue should exist");
        }

        private void EnsureDirectoryExists()
        {
            WorkingDirectory = new DirectoryInfo(System.IO.Path.Combine(Path, Name));

            if (!WorkingDirectory.Exists)
                WorkingDirectory.Create();
        }
    }
}