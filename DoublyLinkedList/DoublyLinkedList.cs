using System;

namespace DataStructures
{
    public class DoublyLinkedList
    {
        public int Count { get; private set; }

        public ListElement First { get; private set; }

        public ListElement Last { get; private set; }

        public ListElement AddFirst(string value)
        {
            var elementToAdd = new ListElement(value, this);

            if (First != null)
            {
                elementToAdd.NextElement = First;
                First.PreviousElement = elementToAdd;
            }
            First = elementToAdd;

            if (Last == null)
            {
                Last = elementToAdd;
            }
            Count++;

            return elementToAdd;
        }

        public ListElement AddLast(string value)
        {
            if (First == null)
            {
                return AddFirst(value);
            }

            var elementToAdd = new ListElement(value, this);

            if (Last == null)
            {
                elementToAdd.PreviousElement = First;
                First.NextElement = elementToAdd;
            }
            else
            {
                elementToAdd.PreviousElement = Last;
                Last.NextElement = elementToAdd;
            }
            Last = elementToAdd;
            Count++;

            return elementToAdd;
        }

        public string GetAndRemoveFirst()
        {
            if(First == null)
            {
                Last = null; 
                Count = 0;
                throw new ElementNotIsListException();
            }

            var elem = First;
            var nextElem = First.NextElement;

            if(nextElem != null)
            {
                First = nextElem;
                nextElem.PreviousElement = null;
            }
            else
            {
                First = null;
                Last = null;
            }
            Count--;
            DetachElement(elem);
            return elem.Value;
        }

        public string GetAndRemoveLast()
        {
            if (Last == null)
            {
                First = null;
                Count = 0;
                throw new ElementNotIsListException();
            }

            var elem = Last;
            var lastElem = Last.PreviousElement;
            if (lastElem != null)
            {
                Last = lastElem;
                lastElem.NextElement = null;
            }
            else
            {
                Last = null;
                First = null;
            }

            Count--;

            DetachElement(elem);
            return elem.Value;
        }

        public void InsertAfter(ListElement element, string value)
        {
            ValidateElement(element);

            if(element.NextElement == null)
            {
                AddLast(value);
                return;
            }

            var elementToAdd = new ListElement(value, this);

            elementToAdd.PreviousElement = element;
            var oldNextElem = element.NextElement;
            elementToAdd.NextElement = oldNextElem;
            oldNextElem.PreviousElement = elementToAdd;
            element.NextElement = elementToAdd;
            Count++;
        }

        public void RemoveElement(ListElement element)
        {
            ValidateElement(element);
            
            if (element.Equals(element.OwnerList.First))
            {
                element.OwnerList.GetAndRemoveFirst();
                return;
            }             
            else if (element.Equals(element.OwnerList.Last))
            {
                element.OwnerList.GetAndRemoveLast();
                return;
            }              

            var findElem = element.OwnerList.First.NextElement;
            while (!findElem.Equals(element))
            {
                if (findElem.NextElement != null)
                    findElem = findElem.NextElement;
                else
                    throw new ElementNotIsListException();
            }
            var previousElem = findElem.PreviousElement;
            var nextElem = findElem.NextElement;
            previousElem.NextElement = nextElem;
            nextElem.PreviousElement = previousElem;
            Count--;
            // After removing element from list
            // we need to nullify its OwnerList property to make it impossible
            // using it again with methods of our list after removing from the list:
            DetachElement(element);
        }

        private void ValidateElement(ListElement element)
        {
            if (element.OwnerList != this)
                throw new ElementNotIsListException();
        }

        private void DetachElement(ListElement element)
        {
            element.OwnerList = null;
            element.PreviousElement = null;
            element.NextElement = null;
        }
    }

    public class ListElement
    {
        internal ListElement(string value, DoublyLinkedList ownerList)
        {
            Value = value;
            OwnerList = ownerList;
        }

        internal DoublyLinkedList OwnerList { get; set; }

        public ListElement PreviousElement { get; internal set; }

        public ListElement NextElement { get; internal set; }

        public string Value { get; private set; }
    }

    public class LinkedListException : Exception { }

    public class ListIsEmptyException : LinkedListException { }

    public class ElementNotIsListException : LinkedListException { }
}