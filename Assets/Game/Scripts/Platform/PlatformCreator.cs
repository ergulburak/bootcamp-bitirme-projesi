#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private PlatformInfo platformBlueprint;
    [SerializeField] private Transform parent;

    [SerializeField] private List<PlatformInfo> _platforms = new List<PlatformInfo>();
    private int _currentDistance;

    [Button]
    private void AddPlatform()
    {
        var newPlatform = PrefabUtility.InstantiatePrefab(platformBlueprint, parent) as PlatformInfo;
        if (newPlatform == null) return;

        _platforms.Add(newPlatform);

        newPlatform.transform.position = new Vector3(0, 0, _currentDistance);

        _currentDistance += newPlatform.Length;
    }

    [Button]
    private void RemovePlatform()
    {
        if (_platforms.IsNullOrEmpty()) return;

        var lastPlatform = _platforms.Last();

        _currentDistance -= lastPlatform.Length;

        _platforms.Remove(lastPlatform);

        DestroyImmediate(lastPlatform.gameObject);
    }
}
#endif