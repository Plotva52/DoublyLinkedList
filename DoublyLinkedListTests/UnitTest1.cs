using System;
using Xunit;

namespace DoublyLinkedListTests
{
    public class UnitTest1
    {
        private DataStructures.DoublyLinkedList list = new DataStructures.DoublyLinkedList();

        [Fact]
        public void AddFirstTest()
        {
            list.AddFirst("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.AddFirst("4");
            string[] expectedSubArray = new string[4] {"4", "3", "2", "1" };
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        [Fact]
        public void AddLastTest()
        {
            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddLast("4");
            string[] expectedSubArray = new string[4] { "1", "2", "3", "4" };
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        [Fact]
        public void AddLastFirstTest()
        {
            list.AddLast("1");
            list.AddFirst("2");
            list.AddLast("3");
            list.AddFirst("4");
            string[] expectedSubArray = new string[4] { "4", "2", "1", "3"};
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        [Fact]
        public void AddFirstAddLastTest()
        {
            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddLast("4");
            list.AddFirst("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.AddFirst("4");
            string[] expectedSubArray = new string[8] { "4", "3", "2", "1", "1", "2", "3", "4" };
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }



        [Fact]
        public void RemoveAllLastTest()
        {
            list.AddLast("1");
            list.AddFirst("2");
            list.AddLast("3");
            list.AddFirst("4");
            list.GetAndRemoveLast();
            list.GetAndRemoveLast();
            list.GetAndRemoveLast();
            list.GetAndRemoveLast();
            Assert.Throws<DataStructures.ElementNotIsListException>(() => list.GetAndRemoveLast());
        }

        [Fact]
        public void RemoveAllFirstTest()
        {
            list.AddLast("1");
            list.AddFirst("2");
            list.AddLast("3");
            list.AddFirst("4");
            list.GetAndRemoveFirst();
            list.GetAndRemoveFirst();
            list.GetAndRemoveFirst();
            list.GetAndRemoveFirst();
            Assert.Throws<DataStructures.ElementNotIsListException>(() => list.GetAndRemoveFirst());
        }

        [Fact]
        public void AddAndRemoveAllTest()
        {
            list.RemoveElement(list.AddLast("1"));
            list.RemoveElement(list.AddFirst("2"));
            list.RemoveElement(list.AddLast("3"));
            list.RemoveElement(list.AddFirst("4"));
            string[] expectedSubArray = new string[0];
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        [Fact]
        public void AllRemoveElementTest()
        {
            list.AddLast("1");
            list.AddLast("2");
            list.AddLast("3");
            list.AddLast("4");
            list.AddFirst("1");
            list.AddFirst("2");
            list.AddFirst("3");
            list.AddFirst("4");

            var elem = list.First;

            while (elem != null)
            {
                list.RemoveElement(elem);
                elem = list.First;
            }

            string[] expectedSubArray = new string[0];
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        [Fact]
        public void InsertAfterTest()
        {
            list.AddLast("1");
            var elem = list.AddLast("2");
            list.AddLast("4");
            list.InsertAfter(elem, "3");

            string[] expectedSubArray = new string[4] { "1", "2", "3", "4" };
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        [Fact]
        public void InsertAfterFirstAndLastTest()
        {
            list.AddLast("1");
            list.AddLast("4");
            list.InsertAfter(list.Last, "5");
            list.InsertAfter(list.First, "3");
            list.InsertAfter(list.First, "2");

            string[] expectedSubArray = new string[5] { "1", "2", "3", "4", "5" };
            Assert.Equal(expectedSubArray, GetValuesFromList());
        }

        private string[] GetValuesFromList()
        {
            string[] actualArray = new string[list.Count];

            var elem = list.First;
            var i = 0;
            while(elem != null)
            {
                actualArray[i] = elem.Value;
                i++;
                elem = elem.NextElement;
            }
            return actualArray;
        }
    }
}
