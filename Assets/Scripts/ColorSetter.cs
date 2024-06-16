using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = _materials[Random.Range(0, _materials.Length)];
    }

}
