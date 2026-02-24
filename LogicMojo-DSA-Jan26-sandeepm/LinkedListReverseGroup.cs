using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class SinglyLinkedListNode
{
    public long data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(long nodeData)
    {
        this.data = nodeData;
        this.next = null;
    }
}

class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(long nodeData)
    {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
        }

        this.tail = node;
    }
}

class SinglyLinkedListPrintHelepr
{
    public static void PrintList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }
}

class Result
{

    /*
     * Complete the 'findLinkedList' function below.
     *
     * The function is expected to return a LONG_INTEGER_SINGLY_LINKED_LIST.
     * The function accepts following parameters:
     *  1. LONG_INTEGER_SINGLY_LINKED_LIST head
     *  2. INTEGER k
     */

    /*
     * For your reference:
     *
     * SinglyLinkedListNode
     * {
     *     long data;
     *     SinglyLinkedListNode next;
     * }
     *
     */

    public static SinglyLinkedListNode findLinkedList(SinglyLinkedListNode head, int k)
    {
        SinglyLinkedListNode dummy = new(0);
        dummy.next = head;
        
        SinglyLinkedListNode current = head, previous=null, previousHead=null, previousTail=null, newHead=null;
        int currentLength = 0;

        //2->1->4->3
        while (current != null)
        {
            if (currentLength == 0)
            {
                previousHead = current; //3
                previous=null;
            }

            SinglyLinkedListNode next = current.next; //null
            current.next = previous;
            previous = current; //4
            current = next; //null
            currentLength++;//2
            
            if (currentLength == k)
            {
                currentLength = 0;
                if (previousTail != null)
                {
                   previousTail.next=previous;
                }                
                previousTail = previousHead;//3
                if (newHead == null)
                {
                    newHead = previous;//2
                }
            }
        }
        
        if (currentLength > 0)
        {
            previousTail.next=previous;
        }

        return newHead;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        SinglyLinkedList l = new SinglyLinkedList();

        int lCount = Convert.ToInt32(Console.ReadLine().Trim());

        for (int i = 0; i < lCount; i++)
        {
            long lItem = Convert.ToInt64(Console.ReadLine().Trim());
            l.InsertNode(lItem);
        }

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        SinglyLinkedListNode result = Result.findLinkedList(l.head, k);

        SinglyLinkedListPrintHelepr.PrintList(result, " ", textWriter);
        textWriter.WriteLine();

        textWriter.Flush();
        textWriter.Close();
    }
}
