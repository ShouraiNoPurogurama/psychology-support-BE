﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.ValueObjects
{
    public record Score
    {
        public int Value { get; }

        public Score(int value)
        {
            if (value < 0 || value > 80)
                throw new ArgumentException("Score must be between 0 and 100.");

            Value = value;
        }
        public static Score Create(int value) => new Score(value);
        public static Score Zero() => new Score(0);
        public override string ToString() => Value.ToString();
    }
}
