using UnityEngine;

public class BuildingButtonController : MonoBehaviour
{
    /// <summary>
    /// Type of building to be selected.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Type of building to be selected.")]
    public BuildingScriptableObject BuildingType;

    public GridController GridController;

    public void SelectBuilding()
    {
        GridController.SelectedBuilding = BuildingType;
    }
}
