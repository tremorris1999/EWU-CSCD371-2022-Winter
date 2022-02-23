using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsHomework;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_MaximumLessThanZero_ThrowsException()
        {
            Node<string> node = new("one");
            node.ChildItems(-42);
        }

        [TestMethod]
        public void ChildItems_Success()
        {
            Node<string> node = new("one");
            node.Add("two");
            node.Add("three");
            string[] expected = { "one", "two", "three" };
            string[] expected2 = { "one", "two" };

            IEnumerable<string> actual = node.ChildItems(node.Count);
            Assert.IsTrue(actual.SequenceEqual(expected));

            actual = node.ChildItems(node.Count + 42);
            Assert.IsTrue(actual.SequenceEqual(expected));

            actual = node.ChildItems(node.Count - 1);
            Assert.IsTrue(actual.SequenceEqual(expected2));
        }
    }
}
