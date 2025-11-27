using UnityEngine;

[CreateAssetMenu(fileName = "BoidData", menuName = "Scriptable Objects/BoidData")]
public class BoidData : ScriptableObject
{
    [Range(0, 10)]
    [SerializeField] private float maxSpeed = 1f;

    [Range(.1f, .5f)]
    [SerializeField] private float maxForce = .03f;

    [Range(1, 10)]
    [SerializeField] private float neighborhoodRadius = 3f;

    [Range(0.1f, 10f)]
    [SerializeField] private float separationRadius = 1f;

    [Range(0, 3)]
    [SerializeField] private float separationAmount = 1f;

    [Range(0, 3)]
    [SerializeField] private float cohesionAmount = 1f;

    [Range(0, 3)]
    [SerializeField] private float alignmentAmount = 1f;

    public float MaxSpeed
    { get { return maxSpeed; } }

    public float MaxForce
    { get { return maxForce; } }

    public float NeighborhoodRadius
    { get { return neighborhoodRadius; } }

    public float SeparationRadius
    { get { return separationRadius; } }

    public float SeparationAmount
    { get { return separationAmount; } }

    public float CohesionAmount
    { get { return cohesionAmount; } }

    public float AlignmentAmount
    { get { return alignmentAmount; } }

}
