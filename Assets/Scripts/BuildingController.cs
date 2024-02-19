using System.Collections;

using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public ResourceManager ResourceManager { get; set; }

    /// <summary>
    /// Building SO which represent the type of building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Building SO which represent the type of building.")]
    public BuildingScriptableObject Type { get; set; }

    private void Start()
    {
        StartCoroutine(DoProductionLoop());
    }

    private IEnumerator DoProductionLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Type.ProductionTime);
            ResourceManager.Resources.Add(Type.ResourceType.ID, Type.ProductionAmount);
        }
    }
}
