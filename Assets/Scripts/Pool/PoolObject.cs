using System.Collections.Generic;
using UnityEngine;

internal class PoolObject : MonoBehaviour
{
    private readonly Stack<GameObject> _stack = new Stack<GameObject>();
    private readonly GameObject _prefab;

    public PoolObject(GameObject prefab)
    {
        _prefab = prefab;
    }

    public GameObject Pop()
    {
        GameObject go;
        if (_stack.Count == 0)
        {
            go = Object.Instantiate(_prefab);
        }
        else
        {
            go = _stack.Pop();
        }
        go.SetActive(true);

        return go;    
    }

    public void Push(GameObject go)
    {
        _stack.Push(go);
        go.SetActive(false);
    }
}