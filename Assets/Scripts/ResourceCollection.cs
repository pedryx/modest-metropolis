using System;
using System.Diagnostics;

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

    /// <summary>
    /// Adds specified quantity to resource of specified id.
    /// </summary>
    public void Add(int id, int quantity)
    {
        Debug.Assert(quantity > 0);

        Quantities[id] += quantity;
    }

    /// <summary>
    /// Remove from this collection specified amounts of resources.
    /// </summary>
    /// <param name="resources">The specified amounts of resources to remove.</param>
    public void Remove(ResourceCollection resources)
    {
        Debug.Assert(Contains(resources));

        for (int i = 0; i < Quantities.Length; i++)
        {
            Quantities[i] -= resources.Quantities[i];
        }
    }

    /// <summary>
    /// Check if this collection contains the specified amounts of resources.
    /// </summary>
    /// <param name="resources">The specified amounts of resources.</param>
    /// <returns>True if collection have at least specified amount of resources, otherwise false.</returns>
    public bool Contains(ResourceCollection resources)
    {
        for (int i = 0; i < Quantities.Length; i++)
        {
            if (Quantities[i] < resources.Quantities[i])
            {
                return false;
            }
        }

        return true;
    }
}
