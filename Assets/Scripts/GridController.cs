using UnityEngine;

public class GridController : MonoBehaviour
{
    private Grid grid;

    [SerializeField]
    private CameraController cameraController;

    /// <summary>
    /// Game object used to mark selected cell.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Game object used to mark selected cell.")]
    public GameObject CellMarker { get; private set; }

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3? position = cameraController.RaycastMousePosition();
        if (position.HasValue && cameraController.IsInBoundary(position.Value))
        {
            CellMarker.SetActive(true);
            CellMarker.transform.position = grid.CellToWorld(grid.WorldToCell(position.Value));
        }
        else
        {
            CellMarker.SetActive(false);
        }
    }
}
