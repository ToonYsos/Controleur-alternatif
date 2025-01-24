using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeRotation : MonoBehaviour
{
    private Color initialColor;
    private Renderer rend;

    public int minRotateSpeed = 2;
    public int maxRotateSpeed = 6;

    void Start()
    {
        rend = GetComponent<Renderer>(); // Récupère le composant Renderer de l'objet
        initialColor = rend.material.color; // Récupère la couleur initiale du matériau
    }

    void Update()
    {
        // Rotation du cube
        transform.Rotate(
            Random.Range(minRotateSpeed, maxRotateSpeed) * Time.deltaTime,
            Random.Range(minRotateSpeed, maxRotateSpeed) * Time.deltaTime,
            Random.Range(minRotateSpeed, maxRotateSpeed) * Time.deltaTime
        );

        // Exemple de changement de couleur pour tester la condition
        if (rend.material.color != initialColor)
        {
            // Si la couleur a changé, augmenter la vitesse de rotation
            minRotateSpeed += 2;
            maxRotateSpeed += 2;

            // Mettre à jour initialColor avec la nouvelle couleur pour éviter d'entrer dans une boucle infinie
            initialColor = rend.material.color;
        }
    }
}
