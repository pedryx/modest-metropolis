using UnityEngine;

public class GridController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Grid grid;

    // TODO: dleete
    [field: SerializeField]
    public Transform CellMarker { get; private set; }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Camera.Enable();

        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        Vector3? position = RaycastMousePosition();
        if (position.HasValue)
        {
            CellMarker.position = grid.CellToWorld(grid.WorldToCell(position.Value));
        }
    }

    // TODO: delete
    private Vector3? RaycastMousePosition()
    {
        Plane plane = new(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(playerInputActions.Camera.ScreenPosition.ReadValue<Vector2>());

        if (plane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        return null;
    }
}
