using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet d'accéder à la propriété "Image"
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health = 75f;
    public float maxHealth = 100f;

    // Image correspondant à notre barre de vie rouge
    public Image healthBar;
    void Update()
    {
        //1 : Référence à la propriété fillAmount de l'image
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