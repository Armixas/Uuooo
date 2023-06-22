using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private float velocity = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = transform.forward * velocity;
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
        CreateExplosionEffect();
    }

    private void CreateExplosionEffect()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
