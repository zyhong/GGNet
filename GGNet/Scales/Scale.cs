﻿using System.Collections.Generic;
using System.Linq;

using GGNet.Transformations;

namespace GGNet.Scales
{
    public interface IScale
    {
        public void Set();

        public void Clear();
    }

    public abstract class Scale<TKey, TValue> : IScale
    {
        protected readonly ITransformation<TKey> transformation;

        public Scale(ITransformation<TKey> transformation = null)
        {
            this.transformation = transformation ?? Transformations.Identity<TKey>.Instance;

            Breaks = Enumerable.Empty<TValue>();
            MinorBreaks = Enumerable.Empty<TValue>();
            Labels = Enumerable.Empty<(TValue value, string text)>();
            Titles = Enumerable.Empty<(TValue value, string text)>();
        }

        public IEnumerable<TValue> Breaks { get; protected set; }

        public IEnumerable<TValue> MinorBreaks { get; protected set; }

        public IEnumerable<(TValue value, string label)> Labels { get; protected set; }

        public IEnumerable<(TValue value, string title)> Titles { get; protected set; }

        public abstract void Train(TKey key);

        public abstract void Set();

        public abstract TValue Map(TKey key);

        public abstract void Clear();
    }
}
