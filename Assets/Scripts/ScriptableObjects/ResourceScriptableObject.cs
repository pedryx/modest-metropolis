using UnityEngine;

/// <summary>
/// Represent a type of resource.
/// </summary>
[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/Resource")]
public class ResourceScriptableObject : GlobalScritableObject<ResourceScriptableObject>
{
    /// <summary>
    /// Resource name.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Name of the resource.")]
    public string Name { get; private set; }
}
