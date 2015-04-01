using System.IO;
using Fish.Mq.Tests.Fixtures;
using Shouldly;
using Xunit;

namespace Fish.Mq.Tests.Queues
{
    public class When_constructing_a_queue : IClassFixture<IsolatedWorkingDirectory>
    {
        private IsolatedWorkingDirectory WorkingDirectory { get; set; }
        private const string QueueName = "Queue1";

        public When_constructing_a_queue(IsolatedWorkingDirectory workingDirectory)
        {
            WorkingDirectory = workingDirectory;
        }

        [Fact]
        public void it_creates_the_queue_folder()
        {
            var queue = new MessageQueue(WorkingDirectory.Path, QueueName);

            var path = Path.Combine(WorkingDirectory.Path, QueueName);

            Directory.Exists(path).ShouldBe(true);
        }

        [Fact]
        public void it_retains_the_queue_name()
        {
            var queue = new MessageQueue(WorkingDirectory.Path, QueueName);

            queue.Name.ShouldBe(QueueName);
        }

        [Fact]
        public void it_retains_the_path()
        {
            var queue = new MessageQueue(WorkingDirectory.Path, QueueName);

            queue.Path.ShouldBe(WorkingDirectory.Path);
        }
    }
}