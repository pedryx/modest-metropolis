using UnityEngine;

public class GridController : Singleton<GridController>
{
    private PlayerInputActions playerInputActions;
    private Grid grid;

    /// <summary>
    /// Controller of main camera.
    /// </summary>
    [SerializeField]
    [Tooltip("Controller of main camera.")]
    private CameraController cameraController;

    /// <summary>
    /// Game object used to mark selected cell.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Game object used to mark selected cell.")]
    public GameObject CellMarker { get; private set; }

    /// <summary>
    /// Manager of placed buildings.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Manager of placed buildings.")]
    public GameObject BuildingManager { get; private set; }

    /// <summary>
    /// Prefab of general building which can be placed.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Prefab of general building which can be placed.")]
    public GameObject BuildingPrefab { get; private set; }

    /// <summary>
    /// Building which is currently selected for placement.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Building which is currently selected for placement.")]
    public BuildingScriptableObject SelectedBuilding { get; set; }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Build.Enable();

        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3? position = cameraController.RaycastMousePosition();
        if (position.HasValue && cameraController.IsInBoundary(position.Value))
        {
            CellMarker.SetActive(true);
            CellMarker.transform.position = grid.CellToWorld(grid.WorldToCell(position.Value)) + grid.cellSize / 2.0f;

            if (!(playerInputActions.Build.PlaceBuilding.WasPressedThisFrame() && SelectedBuilding != null))
                return;
            if (!ResourceManager.Instance.Resources.Contains(SelectedBuilding.Cost))
                return;

            ResourceManager.Instance.Resources.Remove(SelectedBuilding.Cost);

            GameObject building = Instantiate
            (
                BuildingPrefab, 
                CellMarker.transform.position, 
                Quaternion.identity, 
                BuildingManager.transform
            );
            building.GetComponent<BuildingController>().Type = SelectedBuilding;
        }
        else
        {
            CellMarker.SetActive(false);
        }
    }
}
