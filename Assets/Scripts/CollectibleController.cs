using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _collectibles = new List<GameObject>();
    [SerializeField]
    private int count = 3;
    [SerializeField]
    private Vector3 size = new Vector3 (16f, 0, 16f);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateCollectibles();
    }

    private void CreateCollectibles()
    {
        for (int i = 0; i < count; i++)
        {
            foreach (var collectible in _collectibles)
            {
                CreateCollectible(collectible);
            }
        }
    }

    private void CreateCollectible(GameObject collectible)
    {
        Instantiate(collectible, GetRandomPosition(), collectible.transform.rotation, gameObject.transform);
    }

    public void CreateCollectible() 
    {
        var randomCollectible = _collectibles.OrderBy(_collectibles => Random.value).FirstOrDefault();

        if (randomCollectible == null)
            return;
        CreateCollectible(randomCollectible);
    }

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(Random.Range(0, size.x),
            Random.Range(0, size.y), Random.Range(0, size.z));
        return transform.position + volumePosition - size/2;
    }
}
