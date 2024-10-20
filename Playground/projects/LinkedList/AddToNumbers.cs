using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.projects.LinkedList
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class AddToNumbers
    {
        public static void Start()
        {
            var list1 = new ListNode(9);
            var list2 = new ListNode(1,
            new ListNode(9,
                new ListNode(9,
                    new ListNode(9,
                        new ListNode(9,
                            new ListNode(9,
                                new ListNode(9,
                                    new ListNode(9,
                                        new ListNode(9,
                                            new ListNode(9))))))))));



            var value1 = long.Parse(GetValuesFromLinkedList(list1).Reverse().ToArray());
            var value2 = long.Parse(GetValuesFromLinkedList(list2).Reverse().ToArray());

            //Console.WriteLine(value1 + value2);
            var val3 = value1 + value2;
            var res = NumbersToListNode(val3.ToString().Reverse().ToArray());

             
            Console.WriteLine(GetValuesFromLinkedList(res));
        }

        public static ListNode NumbersToListNode(char[] charArr, ListNode list = null, int index = 0)
        {
            if (charArr.Length == index)
            {
                return list;
            }

            int digit = int.Parse(charArr[index].ToString());

            if (list == null)
            {
                list = new ListNode(digit);
            }
            else
            {
                ListNode current = list;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new ListNode(digit);
            }

            return NumbersToListNode(charArr, list, index + 1);
        }


        public static string GetValuesFromLinkedList(ListNode list, string value ="")
        {
            value += list.val.ToString();
            if (list.next != null)
            {
                return GetValuesFromLinkedList(list.next, value);
            }

            return value;
        }

    }
}
