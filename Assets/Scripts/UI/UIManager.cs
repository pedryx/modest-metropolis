using System;

using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Height of labels in resource panel.
    /// </summary>
    private const int resourceItemHeight = 40;
    /// <summary>
    /// Width of buttons in building buttons panel.
    /// </summary>
    private const int buttonItemWidth = 160;

    /// <summary>
    /// Player resources manager.
    /// </summary>
    [SerializeField]
    [Tooltip("Player resources manager.")]
    private ResourceManager resourceManager;
    [SerializeField]
    private GridController gridController;

    /// <summary>
    /// UI panel with resources.
    /// </summary>
    [field: SerializeField]
    [Tooltip("UI panel with resources.")]
    public GameObject ResourcePanel { get; private set; }

    /// <summary>
    /// Prefab of label for resource.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Prefab of label for resource.")]
    public GameObject ResourceNameLabelPrefab { get; private set; }

    /// <summary>
    /// Prefab of quantity label for resource.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Prefab of quantity label for resource.")]
    public GameObject ResourceQuantityLabelPrefab { get; private set; }

    /// <summary>
    /// UI panel with building buttons.
    /// </summary>
    [field: SerializeField]
    [Tooltip("UI panel with building buttons.")]
    public GameObject BuildingButtonsPanel { get; private set; }

    /// <summary>
    /// Prefab of building button.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Prefab of building button.")]
    public GameObject BuildingButtonPrefab { get; private set; }

    private void Awake()
    {
        CreateResourcePanel();
        CreateBuildingButtonsPanel();
    }

    private void CreateResourcePanel()
    {
        var resourceTypes = ResourceScriptableObject.Instances;
        RectTransform rectTransform = ResourcePanel.GetComponent<RectTransform>();

        Vector2 size = rectTransform.sizeDelta;
        size.y = resourceItemHeight * resourceTypes.Count;
        rectTransform.sizeDelta = size;

        for (int i = 0; i < resourceTypes.Count; i++)
        {
            GameObject nameLabel = Instantiate(ResourceNameLabelPrefab, rectTransform);
            nameLabel.GetComponent<RectTransform>().localPosition = new Vector3(-95.0f, i * -resourceItemHeight, 0.0f);
            nameLabel.GetComponent<TextMeshProUGUI>().text = resourceTypes[i].Name + ':';

            GameObject quantityLabel = Instantiate(ResourceQuantityLabelPrefab, rectTransform);
            quantityLabel.GetComponent<RectTransform>().localPosition = new Vector3(5.0f, i * -resourceItemHeight, 0.0f);
            quantityLabel.GetComponent<TextMeshProUGUI>().text = resourceManager.Resources.Quantities[i].ToString();
        }
    }

    private void CreateBuildingButtonsPanel()
    {
        var buildingTypes = BuildingScriptableObject.Instances;
        RectTransform rectTransform = BuildingButtonsPanel.GetComponent<RectTransform>();

        Vector2 size = rectTransform.sizeDelta;
        size.x = (buttonItemWidth + 10.0f) * buildingTypes.Count;
        rectTransform.sizeDelta = size;

        for (int i = 0; i < buildingTypes.Count; i++)
        {
            GameObject button = Instantiate(BuildingButtonPrefab, rectTransform);
            button.GetComponent<RectTransform>().localPosition = new Vector3(i * buttonItemWidth - 85.0f, 0.0f, 0.0f);
            button.GetComponentInChildren<TMP_Text>().text = buildingTypes[i].Name;
            button.GetComponent<BuildingButtonController>().BuildingType = buildingTypes[i];
            button.GetComponent<BuildingButtonController>().GridController = gridController;
        }
    }
}
