using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /// <summary>
    /// Resources owned by player.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Resource owned by player.")]
    public ResourceCollection Resources { get; private set; }
}
