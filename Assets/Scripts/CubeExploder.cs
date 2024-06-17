using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private AnimationCurve _explosionCurve;
    [SerializeField] private float _explosionParametresDivider;

    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    public void Explode(List<Cube> explodableObjects)
    {
        Vector3 direction;
        float distance;
        float attenuation;
        float force;
        foreach (Cube explodableObject in explodableObjects)
        {
            Rigidbody rigidBody = explodableObject.GetComponent<Rigidbody>();
            direction = rigidBody.position - transform.position;
            distance = direction.magnitude;
            direction.Normalize();
            attenuation = _explosionCurve.Evaluate(distance / _explosionRadius);
            force = _explosionForce * attenuation;
            rigidBody.AddForce(direction * force, ForceMode.Impulse);
        }
    }

    public void Init()
    {
        _explosionForce = _explosionForce * _explosionParametresDivider;
        _explosionRadius = _explosionRadius * _explosionParametresDivider;
    }
}
