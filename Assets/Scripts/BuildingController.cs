using System.Collections;

using UnityEngine;

public class BuildingController : MonoBehaviour
{
    /// <summary>
    /// Building SO which represent the type of building.
    /// </summary>
    [field: SerializeField]
    [Tooltip("Building SO which represent the type of building.")]
    public BuildingScriptableObject Type { get; set; }

    private void Start()
    {
        GameObject building = Instantiate(Type.Model, Vector3.zero, Quaternion.identity, transform);
        building.transform.localPosition = Vector3.zero;

        StartCoroutine(DoProductionLoop());
    }

    private IEnumerator DoProductionLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Type.ProductionTime);
            ResourceManager.Instance.Resources.Add(Type.ResourceType.ID, Type.ProductionAmount);
        }
    }
}
