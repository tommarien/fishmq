using System;
using System.IO;
using Fish.Mq.Tests.Fixtures;
using Shouldly;
using Xunit;

namespace Fish.Mq.Tests.Queues
{
    public class When_constructing_a_queue_with_unexisting_working_path : IClassFixture<IsolatedWorkingDirectory>
    {
        private IsolatedWorkingDirectory WorkingDirectory { get; set; }

        public When_constructing_a_queue_with_unexisting_working_path(IsolatedWorkingDirectory workingDirectory)
        {
            WorkingDirectory = workingDirectory;
        }

        [Fact]
        public void it_throws_an_exception()
        {
            var unexistingPath = Path.Combine(WorkingDirectory.Path, "UnExisting");

            Should.Throw<GoFishException>(() => new MessageQueue(unexistingPath, "AQueue"))
                .Message.ShouldBe("The root path for a message queue should exist");
        }

        [Fact]
        public void guard_it_does_not_create_the_directory()
        {
            var unexistingPath = Path.Combine(WorkingDirectory.Path, "UnExisting");

            try
            {
                new MessageQueue(unexistingPath, "Queue1");
            }
            catch (Exception)
            {
            }

            Directory.Exists(unexistingPath).ShouldBe(false);
        }
    }
}