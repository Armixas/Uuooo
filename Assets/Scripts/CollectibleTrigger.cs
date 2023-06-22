using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleTrigger : MonoBehaviour
{
    [SerializeField]
    private int pillValue = 1;
    [SerializeField]
    private int ammoValue = 3;

    private CollectibleController collectibleController;
    private Player player;

    private string medicalPillTag = "MedicalPill";
    private string ammoTag = "Ammo";

    private void Awake()
    { 
        collectibleController = FindObjectOfType<CollectibleController>();
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGO = other.gameObject;
        var collected = false;

        if (IsMedicalPill(otherGO))
        {
            player.AddLives(pillValue);
            collected = true;

        }
        else if (IsAmmo(otherGO))
        {
            player.AddAmmo(ammoValue);
            collected = true;
        }
        if (collected)
        {
            otherGO.SetActive(false);
            Destroy(otherGO);
            collectibleController.CreateCollectible();
        }
    }
    private bool IsMedicalPill(GameObject obj) => obj.CompareTag(medicalPillTag);
    private bool IsAmmo(GameObject obj) => obj.CompareTag(ammoTag);
}
