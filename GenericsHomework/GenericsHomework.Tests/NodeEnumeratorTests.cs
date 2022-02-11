using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeEnumeratorTests
    {
        private Node<string>? _Node;

        [TestInitialize]
        public void Init()
        {
            _Node = new("0");
            _Node.Add("1");
            _Node.Add("2");
        }

        [TestMethod]
        public void NodeEnumerator_Success()
        {
            NodeEnumerator<string> nodeEnumerator = new(_Node!);
            Assert.IsNotNull(nodeEnumerator);
            Assert.IsNotNull(nodeEnumerator._Collection);
            Assert.IsNotNull(nodeEnumerator.CurNode);
        }

        [TestMethod]
        public void IEnumerate_Implementation_Success()
        {
            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            foreach(string s in _Node!)
            {
                Console.WriteLine(s);
            }

            _Node = _Node.Next;

            foreach (string s in _Node!)
            {
                Console.WriteLine(s);
            }

            Assert.AreEqual($"0{Environment.NewLine}1{Environment.NewLine}2{Environment.NewLine}", stringWriter.ToString());
        }

    }
}
