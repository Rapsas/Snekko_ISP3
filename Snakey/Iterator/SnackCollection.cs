﻿namespace Snakey.Iterator;

using Snakey.Models;
using System;
using System.Collections.Generic;

public class SnackCollection : IIterableCollection
{
    List<Snack> Snacks;
    public int Count { get => Length(); }

    public SnackCollection()
    {
        this.Snacks = new();
    }
    public IIterator CreateIterator()
    {
        return new SnackIterator(Snacks);
    }

    public void Add(Snack line)
    {
        this.Snacks.Add(line);
    }

    public void Clear()
    {
        this.Snacks.Clear();
    }

    public void RemoveAll(Predicate<Snack> predicate)
    {
        this.Snacks.RemoveAll(predicate);
    }

    public void ForEach(Action<Snack> action)
    {
        this.Snacks.ForEach(action);
    }

    int Length() => Snacks.Count;
}
