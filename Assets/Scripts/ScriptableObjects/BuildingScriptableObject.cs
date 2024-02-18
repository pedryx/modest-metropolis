using UnityEngine;

/// <summary>
/// Represent a type of building.
/// </summary>
[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building")]
public class BuildingScriptableObject : GlobalScritableObject<BuildingScriptableObject>
{
    public Color Color = Color.white;

    /// <summary>
    /// Name of the building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Name of the building.")]
    public string Name { get; private set; }
}
