using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    private List<IDrive> _drivers = new();

    public void AddDriver(IDrive driver) => _drivers.Add(driver);
    void Update()
    {
        Transform first = GetFirstDriver();
        if (first == null) return;

        Debug.Log($"1st {first.gameObject.name}");
    }

    /// <summary>
    ///    get 1st driver
    /// </summary>
    /// <returns></returns>
    private Transform GetFirstDriver()
    {
        return _drivers
            .OrderBy(n => -n.transform.position.y)
            .First().transform;
    }

    public interface IDrive
    {
        public Transform transform { get; }
    }
}
