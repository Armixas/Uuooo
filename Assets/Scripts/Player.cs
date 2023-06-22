using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private int ammo = 3;

    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI ammoText;
    [SerializeField]
    private TextMeshProUGUI gameOverText;

    private PlayerController _playerController;


    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesText();
        UpdateAmmoText();
    }

    private void UpdateLivesText() => livesText.text = $"Lives: {lives}";
    private void UpdateAmmoText() => ammoText.text = $"Ammo: {ammo}";

    public void AddLives(int value)
    {
        lives += value;
        UpdateLivesText();
    }
    public void AddAmmo(int value)
    {
        ammo += value;
        UpdateAmmoText();
    }

    public void TakeDamage()
    {
        lives--;
        UpdateLivesText();
        if (lives <= 0)
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        _playerController.enabled = false;
        gameOverText.gameObject.SetActive(true);
    }

}
