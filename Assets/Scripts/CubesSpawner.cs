using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private int _minCubesAmount;
    [SerializeField] private int _maxCubesAmount;
    [SerializeField] private float _scaleDivider;

    public List<Cube> DivideCube(float chanse, Cube cube)
    {
        int cubesAmount = Random.Range(_minCubesAmount, _maxCubesAmount);
        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < cubesAmount; i++)
        {
            Cube spawnedCube = Instantiate(cube, transform.position, Quaternion.identity);
            spawnedCube.SetDevisionChanse(chanse);
            spawnedCube.gameObject.transform.localScale = transform.localScale / _scaleDivider;
            cubes.Add(spawnedCube);
        }
        
        return cubes;
    }
}
