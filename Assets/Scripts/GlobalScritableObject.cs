using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Base class for scriptable objects which stores all instances in global array.
/// </summary>
public abstract class GlobalScritableObject<TChild> : ScriptableObject
    where TChild : GlobalScritableObject<TChild>
{
    /// <summary>
    /// Contains all instantiated resource scriptable objects.
    /// </summary>
    private static List<TChild> instances = new();

    /// <summary>
    /// Contains all instantiated resource scriptable objects.
    /// </summary>
    public static IReadOnlyList<TChild> Instances => instances;

    /// <summary>
    /// ID of resource type. Can be used as an index into quantity arrays.
    /// </summary>
    public int ID { get; } = instances.Count;

    protected GlobalScritableObject()
    {
        instances.Add(this as TChild);
    }
}
