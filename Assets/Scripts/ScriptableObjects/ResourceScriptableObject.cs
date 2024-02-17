using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Represent a type of resource.
/// </summary>
[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/Resource")]
public class ResourceScriptableObject : ScriptableObject
{
    /// <summary>
    /// Contains all instantiated resource scriptable objects.
    /// </summary>
    private static List<ResourceScriptableObject> instances = new();

    /// <summary>
    /// Contains all instantiated resource scriptable objects.
    /// </summary>
    public static IReadOnlyList<ResourceScriptableObject> Instances => instances;

    /// <summary>
    /// ID of resource type. Can be used as an index into quantity arrays.
    /// </summary>
    public int ID { get; } = instances.Count;

    /// <summary>
    /// Resource name.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Name of the resource.")]
    public string Name { get; private set; }

    public ResourceScriptableObject()
    {
        instances.Add(this);
    }
}
