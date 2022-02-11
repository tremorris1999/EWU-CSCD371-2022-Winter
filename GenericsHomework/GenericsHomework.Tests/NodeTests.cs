using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod, TestCategory("Construction")]
        public void Node_AnyValue_Success()
        {
            Node<string> node = new(null!); // null
            Node<string> node1 = new(string.Empty); // not null
            Assert.IsInstanceOfType(node, typeof(Node<string>));
            Assert.IsInstanceOfType(node1, typeof(Node<string>));
        }

        [TestMethod, TestCategory("Construction")]
        public void Node_IsCircularlyLinked()
        {
            Node<string> node = new("0");
            Assert.ReferenceEquals(node, node.Next);

            node.Add("1");
            Assert.ReferenceEquals(node, node.Next.Next);

            node.Add("2");
            Assert.ReferenceEquals(node, node.Next.Next.Next);
        }

        [TestMethod, TestCategory("Editing")]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ThrowsOnDuplicate()
        {
            Node<string> node = new("0");
            node.Add("0");
        }

        [TestMethod, TestCategory("Editing")]
        public void Add_Success()
        {
            Node<string> node = new("0");
            node.Add("1");
            Assert.IsTrue(node.Value.CompareTo("0") == 0);
        }

        [TestMethod, TestCategory("Editing")]
        public void Clear_Success()
        {
            Node<String> node = new("0");
            node.Add("1");
            node.Add("2");
            node.Add("3");
            node.Clear();
            Assert.ReferenceEquals(node, node.Next);
        }

        [TestMethod, TestCategory("Editing")]
        public void Remove_NotInList_Failure()
        {
            Node<string> node = new("0");
            bool res = node.Remove("42");
            Assert.IsFalse(res);
        }

        [TestMethod, TestCategory("Editing")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_RootNode_Failure()
        {
            Node<string> node = new("0");
            node.Remove("0");
        }

        [TestMethod, TestCategory("Editing")]
        public void Remove_InList_Success()
        {
            Node<string> node = new("0");
            node.Add("1");
            node.Add("2");
            Assert.IsTrue(node.Remove("1"));
            Assert.AreEqual("2", node.Next.Value);
        }

        [TestMethod, TestCategory("Accessing")]
        public void Contains_DoesExist()
        {
            Node<String> node = new("0");
            node.Add("1");
            Assert.IsTrue(node.Contains("0"));
            Assert.IsTrue(node.Contains("1"));
        }

        [TestMethod, TestCategory("Accessing")]
        public void Contains_DoesNotExist()
        {
            Node<String> node = new("0");
            Assert.IsFalse(node.Contains("42"));
        }

        [TestMethod, TestCategory("Accessing")]
        public void ToString_ReturnsCorrectly()
        {
            Node<string> node = new("0");
            Assert.AreEqual(node.ToString(), node.Value.ToString());
        }

        [TestMethod, TestCategory("Accessing")]
        public void GetEnumerator_Success()
        {
            Node<string> node = new("0");
            Assert.IsInstanceOfType(node.GetEnumerator(), typeof(NodeEnumerator<string>));
        }

        [TestMethod, TestCategory("Accessing")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyTo_NullArray_Failure()
        {
            Node<string> node = new("0");
            node.CopyTo(null!, 0);
        }

        [TestMethod, TestCategory("Accessing")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_NegativeIndex_Failure()
        {
            Node<string> node = new("0");
            node.CopyTo(Array.Empty<string>(), -42);
        }

        [TestMethod, TestCategory("Accessing")]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_SmallerArray_Failure()
        {
            Node<string> node = new("0");
            node.Add("1");
            node.CopyTo(Array.Empty<string>(), 0);
        }

        [TestMethod, TestCategory("Accessing")]
        public void CopyTo_Success()
        {
            string[] arr = new string[5];
            string[] expected = { "0", "1", "2" };
            Node<string> node = new("0");
            node.Add("1");
            node.Add("2");
            node.CopyTo(arr, 0);
            Assert.AreEqual(expected[0], arr[0]);
            Assert.AreEqual(expected[1], arr[1]);
            Assert.AreEqual(expected[2], arr[2]);
        }
    }
}