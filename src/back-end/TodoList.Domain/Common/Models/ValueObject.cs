﻿using System.Diagnostics.CodeAnalysis;

namespace TodoList.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)obj;


            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        #pragma warning disable CS8618
        [ExcludeFromCodeCoverage(Justification = "Required by EF Core")]
        protected ValueObject()
        {
        }
        #pragma warning restore CS8618
    }
}
