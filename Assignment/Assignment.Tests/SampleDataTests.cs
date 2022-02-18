using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_LazyInitialize_Success()
        {
            SampleData sampleData = new();
            Assert.IsNotNull(sampleData.CsvRows);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_Success()
        {
            SampleData sampleData = new();
            var q = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsNotNull(q);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_IsDistinct()
        {
            SampleData sampleData = new();
            var q = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(q.SequenceEqual(q.Distinct()));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_IsSorted()
        {
            SampleData sampleData = new();
            var q = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.IsTrue(q.SequenceEqual(q.OrderBy(item => item)));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStates_HardcodedSpokaneList()
        {
            List<string> list = new List<string>();
            list.Add("id,first,last,email,address,Spokane,WA");
            list.Add("id,first,last,email,address,Spokane,WA");
            list.Add("id,first,last,email,address,Spokane,WA");
            var mockIEnumerble = new Mock<SampleData>();
            /**
             * TODO: ask for clarification and finish
             */
        }
    }
}
