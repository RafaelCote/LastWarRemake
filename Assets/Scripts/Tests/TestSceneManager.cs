using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab = null;
    [SerializeField] private float _a, _b, _c;

    private List<GameObject> _instances = new List<GameObject>();
    
    private void Start()
    {
        SpawnCubeInParapoble();
    }

    [ContextMenu("Clean and spawn cubes")]
    private void SpawnCubeInParapoble()
    {
        foreach (var instance in _instances)
        {
            Destroy(instance);
        }
        _instances.Clear();

        
        for (float i = 0; i <= 1; i += 0.1f)
        {
            var instance = Instantiate(_prefab);
            instance.transform.position = Vector3.Slerp(new Vector3(-5.0f, 0.0f, 0.0f), new Vector3(5.0f, 1.0f, 0.0f), i);
            _instances.Add(instance);
        }
    }
}
