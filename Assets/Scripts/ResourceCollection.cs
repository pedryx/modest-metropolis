using System;

/// <summary>
/// Represent a collection of resources.
/// </summary>
[Serializable]
public class ResourceCollection
{
    /// <summary>
    /// Arrays of quantities. You can use <see cref="ResourceScriptableObject.ID"/> as index to obtain quantity of
    /// desired resource type.
    /// </summary>
    public int[] Quantities;

    public ResourceCollection()
    {
        Quantities = new int[ResourceScriptableObject.Instances.Count];
    }
}
