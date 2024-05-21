using Playground.pg._8.record;
using Playground.pg._9_pattern_matching.type;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.pg._10_collections.linkedlist
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; } = null;

        public Node(T value)
        {
            Value = value;
        }
    }

    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedList<T> LinkedList;
        public LinkedListEnumerator(LinkedList<T> linkedList)
        {
            LinkedList = linkedList;
        }

        private Node<T> CurrentNode { get; set; }

        public T Current => (CurrentNode ?? throw new Exception()).Value;

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (CurrentNode == null)
            {
                CurrentNode = LinkedList.Root;
                return CurrentNode != null;
            }

            CurrentNode = CurrentNode.Next;
            return CurrentNode != null;
        }

        public void Reset()
        {
            CurrentNode = null;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T> Root { get; set; }
    
        public void PrintAll()
        {
            if (Root == null) return;

            Node<T> current = Root;
            while (current.Next != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
            Console.WriteLine(current.Value);
        }

        public void Add(T val)
        {
            Node<T> current = Root;

            if (Root == null)
            {
                Root = new Node<T>(val);
                return;
            }
            while (current.Next != null)
            {
               current = current.Next;
            }
            current.Next = new Node<T>(val);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        public static void Start()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.Add("string");
            linkedList.Add("integer");

            linkedList.PrintAll();

            foreach(var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
