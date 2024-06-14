using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Material[] _materials;
    [SerializeField] private int _minCubesAmount;
    [SerializeField] private int _maxCubesAmount;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _divisionChanse;
    [SerializeField] private int _minDivisionChanse;
    [SerializeField] private int _maxDivisionChanse;
    [SerializeField] private float _scaleDivider;
    [SerializeField] private float _divisionChanseDivider;

    public Cube ParentCube => _parentCube;
    private Cube _parentCube;

    private void Start()
    {
        Renderer rendered = GetComponent<Renderer>();
        rendered.material = _materials[Random.Range(0, _materials.Length)];
    }

    private void OnMouseUpAsButton()
    {
        float randomDivisionChanse = Random.Range(_minDivisionChanse, _maxDivisionChanse);

        if (_divisionChanse >= randomDivisionChanse)
        {
            SpawnCubes();
            Destroy(gameObject);
        }
        else
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null && hit.gameObject.GetComponent<Cube>().ParentCube == this)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < Random.Range(_minCubesAmount, _maxCubesAmount); i++)
        {
            Cube spawnedCube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            spawnedCube.SetParentCube(this);
            spawnedCube.SetDevisionChanse(_divisionChanse / _divisionChanseDivider);
            spawnedCube.gameObject.transform.localScale = transform.localScale / _scaleDivider;
        }
    }

    public void SetParentCube(Cube parentCube)
    {
        _parentCube = parentCube;
    }

    public void SetDevisionChanse(float divisionChanse)
    {
        _divisionChanse = divisionChanse;
    }
}
