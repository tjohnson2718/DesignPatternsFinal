using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DesignPatternsFinal.Builder;
using DesignPatternsFinal.Models;

namespace Test.Builder
{
    [TestFixture]
    public class TaskBuilderTests
    {
        [Test]
        public void Builder_CreatesTaskWithAllProperties()
        {
            // Arrange
            var builder = new TaskBuilder();

            // Act
            var task = builder
                .SetTitle("Test Task")
                .SetDescription("A test description")
                .SetDueDate(new DateTime(2025, 5, 28))
                .SetPriority(2)
                .SetTags(new List<string> { "work", "urgent" })
                .SetEstimatedDuration(TimeSpan.FromHours(1))
                .Build();

            // Assert
            Assert.AreEqual("Test Task", task.Title);
            Assert.AreEqual("A test description", task.Description);
            Assert.AreEqual(new DateTime(2025, 5, 28), task.DueDate);
            Assert.AreEqual(2, task.Priority);
            CollectionAssert.AreEqual(new List<string> { "work", "urgent" }, task.Tags);
            Assert.AreEqual(TimeSpan.FromHours(1), task.EstimatedDuration);
        }

        [Test]
        public void Builder_ThrowsIfTitleMissing()
        {
            var builder = new TaskBuilder();
            Assert.Throws<ArgumentException>(() => builder.Build());
        }
    }
}
