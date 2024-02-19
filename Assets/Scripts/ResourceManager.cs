using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    /// <summary>
    /// Resources owned by player.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Resource owned by player.")]
    public ResourceCollection Resources { get; private set; }
}
