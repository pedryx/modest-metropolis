using UnityEngine;

public class BuildingButtonController : MonoBehaviour
{
    /// <summary>
    /// Type of building to be selected.
    /// </summary>
    [Tooltip("Type of building to be selected.")]
    public BuildingScriptableObject BuildingType;

    public void SelectBuilding()
    {
        GridController.Instance.SelectedBuilding = BuildingType;
    }
}
