﻿namespace GGNet.Scales
{
    public class Identity<T> : Scale<T, T>
    {
        public Identity() : base(null) { }

        public override void Train(T key) { }

        public override void Set() { }

        public override T Map(T key) => key;

        public override void Clear() { }
    }
}
