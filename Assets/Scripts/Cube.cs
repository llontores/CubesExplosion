using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _startDivisionChanse;
    [SerializeField] private int _minDivisionChanse;
    [SerializeField] private int _maxDivisionChanse;
    [SerializeField] private float _divisionChanseDivider;
    [SerializeField] private CubesSpawner _cubesSpawner;
    [SerializeField] private CubeExploder _cubeExploder;

    private List<Cube> _explodableCubes = new();

    private void OnMouseUpAsButton()
    {
        float randomDivisionChanse = Random.Range(_minDivisionChanse, _maxDivisionChanse);

        if (_startDivisionChanse >= randomDivisionChanse)
        {
            _explodableCubes = _cubesSpawner.DivideCube(_startDivisionChanse / _divisionChanseDivider, this);
            Destroy(gameObject);
        }
        else
        {
            if (_cubesSpawner != null)
                _cubeExploder.Explode(_explodableCubes);
            Destroy(gameObject);
        }
    }

    public void Init(float divisionChanse)
    {
        _startDivisionChanse = divisionChanse;
    }
}
