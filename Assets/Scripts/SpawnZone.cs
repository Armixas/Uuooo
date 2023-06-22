using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private Vector3 size = new Vector3 (16f, 0, 16f);

    private void OnDrawGizmos()
    {
        var spawnZoneTransform = transform;
        Gizmos.matrix = spawnZoneTransform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, size);
    }
    public void Create(GameObject otherGO)
    {
        var position = GetRandomPosition();
        var rotation = otherGO.transform.rotation;
        var parent = transform.parent;

        Instantiate(otherGO, position, rotation, parent);

    }
    private Vector3 GetRandomPosition()
    {
        var randomPosition = new Vector3(Random.Range(0, size.x),
            Random.Range(0, size.y), Random.Range(0, size.z));

        var spawnZoneTransform = transform;
        var rotatedPosition = spawnZoneTransform.rotation * (randomPosition - size / 2);
        return spawnZoneTransform.position + rotatedPosition;
    }
}
