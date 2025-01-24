using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet d'acc�der � la propri�t� "Image"
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health = 75f;
    public float maxHealth = 100f;

    // Image correspondant � notre barre de vie rouge
    public Image healthBar;
    void Update()
    {
        //1 : R�f�rence � la propri�t� fillAmount de l'image
        //2 : Pourcentage entre la vie et la vie maximale (chiffre entre 0 et 1)
        healthBar.fillAmount = health / maxHealth;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void Health(int healthAmount)
    {
        health += healthAmount;
    }
}