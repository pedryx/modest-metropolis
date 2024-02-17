using UnityEngine;

/// <summary>
/// Represent a type of building.
/// </summary>
[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building")]
public class BuildingScriptableObject : ScriptableObject
{
    public Color Color = Color.white;
}
