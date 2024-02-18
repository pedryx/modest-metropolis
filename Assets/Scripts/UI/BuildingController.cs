using UnityEngine;

public class BuildingController : MonoBehaviour
{
    /// <summary>
    /// Building SO which represent the type of building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Building SO which represent the type of building.")]
    public BuildingScriptableObject Type { get; set; }
}
