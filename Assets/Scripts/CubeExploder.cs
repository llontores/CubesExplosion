using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Cube> explodableObjects)
    {
        foreach (Cube explodableObject in explodableObjects)
        {
            Rigidbody rigidBody = explodableObject.GetComponent<Rigidbody>();
            rigidBody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
