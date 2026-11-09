using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    public static bool operator ==(Entity left, Entity right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !left.Equals(right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Entity)
            return false;

        return Equals(obj as Entity);
    }

    private bool Equals(Entity entity) => Id == entity.Id;

    public override int GetHashCode() => Id.GetHashCode();
}