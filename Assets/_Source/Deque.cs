﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//успешно украдено с метанит, ибо мне лень сейчас двунаправленную очередь писать

public class Deque<T> : IEnumerable<T>  // двусвязный список
{
    DoublyNode<T> head; // головной/первый элемент
    DoublyNode<T> tail; // последний/хвостовой элемент
    int count;  // количество элементов в списке

    int maxCount = 30; //а вот это я уже добавил, это по тз

    // добавление элемента
    public void AddLast(T data)
    {
        DoublyNode<T> node = new DoublyNode<T>(data);

        if (head == null)
            head = node;
        else
        {
            tail.Next = node;
            node.Previous = tail;
        }
        tail = node;
        count++;
        if (count > maxCount)
            RemoveFirst();
    }
    /*public void AddFirst(T data)
    {
        DoublyNode<T> node = new DoublyNode<T>(data);
        DoublyNode<T> temp = head;
        node.Next = temp;
        head = node;
        if (count == 0)
            tail = head;
        else
            temp.Previous = node;
        count++;
    }*/
    public T RemoveFirst()
    {
        if (count == 0)
            throw new Exception("Queue is empty");
        T output = head.Data;
        if (count == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.Next;
            head.Previous = null;
        }
        count--;
        return output;
    }
    public T RemoveLast()
    {
        Debug.Log(count);
        if (count == 0)
            throw new Exception("Queue is empty");
        T output = tail.Data;
        if (count == 1)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.Previous;
            tail.Next = null;
        }
        count--;
        return output;
    }
    public T First
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return head.Data;
        }
    }
    public T Last
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return tail.Data;
        }
    }

    public int Count { get { return count; } }
    public bool IsEmpty { get { return count == 0; } }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public bool Contains(T data)
    {
        DoublyNode<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        DoublyNode<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}


public class DoublyNode<T>
{
    public DoublyNode(T data)
    {
        Data = data;
    }
    public T Data { get; set; }
    public DoublyNode<T> Previous { get; set; }
    public DoublyNode<T> Next { get; set; }
}