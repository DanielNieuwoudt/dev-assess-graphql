﻿using System.Diagnostics.CodeAnalysis;

namespace TodoList.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            Id = id;
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        {
            return left?.Equals(right) ?? right is null;
        }

        public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #pragma warning disable CS8618
        [ExcludeFromCodeCoverage(Justification = "Required by EF Core")]
        protected Entity()
        {
        }
        #pragma warning restore CS8618
    }
}
