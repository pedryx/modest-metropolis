using TMPro;

using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /// <summary>
    /// Height of labels in resource panel.
    /// </summary>
    private const int itemHeight = 40;

    /// <summary>
    /// Resources owned by player.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Resource owned by player.")]
    public ResourceCollection Resources { get; private set; }

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

    private void Start()
    {
        var resourceTypes = ResourceScriptableObject.Instances;
        RectTransform rectTransform = ResourcePanel.GetComponent<RectTransform>();

        Vector2 size = rectTransform.sizeDelta;
        size.y = itemHeight * resourceTypes.Count;
        rectTransform.sizeDelta = size;

        for (int i = 0; i < resourceTypes.Count; i++)
        {
            GameObject nameLabel = Instantiate(ResourceNameLabelPrefab, rectTransform);
            nameLabel.GetComponent<RectTransform>().localPosition = new Vector3(-95.0f, i * -itemHeight, 0.0f);
            nameLabel.GetComponent<TextMeshProUGUI>().text = resourceTypes[i].Name + ':';

            GameObject quantityLabel = Instantiate(ResourceQuantityLabelPrefab, rectTransform);
            quantityLabel.GetComponent<RectTransform>().localPosition = new Vector3(5.0f, i * -itemHeight, 0.0f);
            quantityLabel.GetComponent<TextMeshProUGUI>().text = Resources.Quantities[i].ToString();

        }
    }
}
