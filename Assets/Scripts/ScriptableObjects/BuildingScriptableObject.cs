using UnityEngine;

/// <summary>
/// Represent a type of building.
/// </summary>
[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building")]
public class BuildingScriptableObject : GlobalScritableObject<BuildingScriptableObject>
{
    /// <summary>
    /// Name of the building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Name of the building.")]
    public string Name { get; private set; }

    /// <summary>
    /// Type of resource produced by building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Type of resource produced by building.")]
    public ResourceScriptableObject ResourceType { get; private set; }

    /// <summary>
    /// How long it takes to produce resource (in seconds).
    /// </summary>
    [field: SerializeField]
    [Tooltip("How long it takes to produce resource (in seconds).")]
    public float ProductionTime { get; private set; }

    /// <summary>
    /// How many resources will be produced.
    /// </summary>
    [field: SerializeField]
    [Tooltip("How many resources will be produced.")]
    public int ProductionAmount { get; private set; }

    /// <summary>
    /// Cost of the building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Cost of the building.")]
    public ResourceCollection Cost { get; private set; }

    /// <summary>
    /// 3D model of the building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("3D model of the building.")]
    public GameObject Model { get; private set; }
}
