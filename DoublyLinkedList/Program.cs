using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DataStructures.DoublyLinkedList();
          //  var t = list.AddFirst("2");
            list.AddFirst("1");
            list.AddLast("2");
           var t= list.AddFirst("0");
            list.AddLast("3");
            list.AddLast("3");
            list.RemoveElement(t);
            list.GetAndRemoveLast();
            Console.WriteLine(list.First.Value);
            var elem = list.First.NextElement;
            while(elem != null)
            {
                Console.WriteLine(elem.Value);
                elem = elem.NextElement;
            }            
        }
    }
}
