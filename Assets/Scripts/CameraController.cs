using System.Drawing;

using Unity.VisualScripting;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Base width and height of unity's plane game object.
    /// </summary>
    private const float planeBaseSize = 10.0f;

    private PlayerInputActions playerInputActions;
    private Transform cameraTransform;
    private float currentZoom;
    private Vector3? dragStartPosition = null;

    /// <summary>
    /// Transform of terrain plane on which camera is allowed to move.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Transform of terrain plane on which camera is allowed to move.")]
    public Transform TerrainTransform { get; private set; }

    /// <summary>
    /// Camera's movement speed.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Camera's movement speed.")]
    public float MovementSpeed { get; private set; } = 10.0f;

    /// <summary>
    /// Speed of camera's roll rotation.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Speed of camera's roll rotation.")]
    public float RollSpeed { get; private set; } = 100.0f;

    /// <summary>
    /// Sensitivity of camera zoom in/out when using mouse wheel.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Sensitivity of camera zoom in/out when using mouse wheel.")]
    public float ZoomSensitivity { get; private set; } = 1.0f;

    /// <summary>
    /// Minimal allowed zoom of the camera. (Less zoom ~ more zoomed in.)
    /// </summary>
    [field: SerializeField]
    [Tooltip("Minimal allowed zoom of the camera. (Less zoom ~ more zoomed in.)")]
    public float MinZoom { get; private set; } = 10.0f;

    /// <summary>
    /// Maximum allowed zoom of the camera. (More zoom ~ more zoomed out.)
    /// </summary>
    [field: SerializeField]
    [Tooltip("Maximum allowed zoom of the camera. (More zoom ~ more zoomed out.)")]
    public float MaxZoom { get; private set; } = 100.0f;

    public float Mag = 1.0f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Camera.Enable();

        cameraTransform = transform.GetChild(0);
        currentZoom = cameraTransform.localPosition.y;
    }

    private void Update()
    {
        HandleMovement();
        HandleRoll();
        HandleZoom();
        HandleMouseMovement();

        RestrictMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = playerInputActions.Camera.Movement.ReadValue<Vector2>();

        float zoomModifier = 1.0f + (currentZoom - MinZoom) / (MaxZoom - MinZoom);
        float moveDistance = MovementSpeed * zoomModifier * Time.deltaTime;

        transform.localPosition += moveDistance * inputVector.y * transform.forward;
        transform.localPosition += moveDistance * inputVector.x * transform.right;
    }

    private void HandleRoll()
    {
        float direction = playerInputActions.Camera.Roll.ReadValue<float>();

        transform.Rotate(Vector3.up, direction * RollSpeed * Time.deltaTime);
    }

    private void HandleZoom()
    {
        float zoomValue = -playerInputActions.Camera.Zoom.ReadValue<Vector2>().y;

        currentZoom = Mathf.Clamp(currentZoom + zoomValue * ZoomSensitivity, MinZoom, MaxZoom);

        // Zooming in/out is not linear.
        float t = (currentZoom - MinZoom) / (MaxZoom - MinZoom);
        float zoom = Mathf.Lerp(MinZoom, MaxZoom, t * t);

        cameraTransform.localPosition = new Vector3(0.0f, zoom, -zoom);
    }

    private void HandleMouseMovement()
    {
        if (playerInputActions.Camera.DragMovementEnabled.WasPressedThisFrame())
        {
            dragStartPosition = RaycastMousePosition();
        }

        if (playerInputActions.Camera.DragMovementEnabled.IsPressed())
        {
            Vector3? dragCurrentPosition = RaycastMousePosition();

            if (!dragStartPosition.HasValue || !dragCurrentPosition.HasValue)
                return;

            transform.localPosition += dragStartPosition.Value - dragCurrentPosition.Value;
        }
    }

    /// <summary>
    /// Restrict camera's movement, so it is clamped into borders of terrain's plane.
    /// </summary>
    private void RestrictMovement()
    {
        float halfWidth = planeBaseSize * TerrainTransform.localScale.x / 2.0f;
        float halfHeight = planeBaseSize * TerrainTransform.localScale.z / 2.0f;

        transform.localPosition = new Vector3()
        {
            x = Mathf.Clamp(transform.localPosition.x, -halfWidth, halfWidth),
            y = transform.localPosition.y,
            z = Mathf.Clamp(transform.localPosition.z, -halfHeight, halfHeight),
        };
    }

    /// <summary>
    /// Get world position of mouse. If raycast fails, then null is returned.
    /// </summary>
    /// <returns>On succesfull raycast, world position of the mouse, otherwise null.</returns>
    public Vector3? RaycastMousePosition()
    {
        Plane plane = new(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(playerInputActions.Camera.ScreenPosition.ReadValue<Vector2>());

        if (plane.Raycast(ray, out float enter))
        {
            return ray.GetPoint(enter);
        }

        return null;
    }

    /// <summary>
    /// Determine if specified point is in map boundary.
    /// </summary>
    public bool IsInBoundary(Vector3 point)
    {
        float width = planeBaseSize * TerrainTransform.localScale.x;
        float height = planeBaseSize * TerrainTransform.localScale.z;

        return new RectangleF(-width / 2.0f, -height / 2.0f, width, height).Contains(point.x, point.z);
    }
}
