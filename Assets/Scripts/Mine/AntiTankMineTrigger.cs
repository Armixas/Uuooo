using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AntiTankMineTrigger : MonoBehaviour
{
    [SerializeField]
    private string antiTankMineTag = "ATMine";

    [SerializeField]
    private float minExplosiveForce = 3f;

    [SerializeField]
    private float maxExplosiveForce = 5f;

    private AntiTankMineController antiTankMineController;
    private Rigidbody rb;
    private Player player;

    [SerializeField]
    private GameObject explosionPrefab;

    private void Awake()
    {
        antiTankMineController = FindObjectOfType<AntiTankMineController>();
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }
    private void OnCollisionEnter(Collision other)
    {
        var otherGO = other.gameObject;
        if (IsAntiTankMine(otherGO))
        {
            CreateExplosionEffect(other.transform.position);
            AddExplosiveForce();
            otherGO.SetActive(false);
            Destroy(otherGO);
            player.TakeDamage();
            antiTankMineController.CreateMine();
        }
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }

    private bool IsAntiTankMine(GameObject obj) => obj.CompareTag(antiTankMineTag);
    private void AddExplosiveForce()
    {
        var force = Random.Range(minExplosiveForce, maxExplosiveForce);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
