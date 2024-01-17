using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentacleZone : MonoBehaviour
{
    public static RentacleZone instance;
    public float width = 10f;
    public float depth = 10f;
    private void Awake()
    {
        instance = this;
    }
    public Vector3 GetRandomPoint()
    {
        var local = new Vector3(
            (Random.value - 0.5f) * width,
            0,
            (Random.value - 0.5f) * depth);

        return transform.TransformPoint(local);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        var cachedMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, 0, depth));

        Gizmos.matrix = cachedMatrix;
    }
}