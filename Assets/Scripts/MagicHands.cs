using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHands : MonoBehaviour
{
    private RandomColor randomcolor;
    // Start is called before the first frame update
    void Start()
    {
        randomcolor = GetComponent<RandomColor>();
    }

    void Update()
    {
        LeftHand();
        RightHand();
    }

    void LeftHand ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Pouce de la main gauche activé");
        }

        if (Input.GetKey(KeyCode.B))
        {
            Debug.Log("Index de la main gauche activé");
        }

        if(Input.GetKey(KeyCode.C))
        {
            Debug.Log("Majeur de la main gauche activé");
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Anullaire de la main gauche activé");
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Auriculaire la main gauche activé");
        }
    }

    void RightHand ()
    {

        if(Input.GetKey(KeyCode.J))
        {
            Debug.Log("Pouce de la main droite activé");
        }

        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("Index de la main droite activé");
        }

        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("Majeur de la main droite activé");
        }

        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("Anullaire de la main droite activé");
        }

        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("Auriculaire la main droite activé");
        }


    }
}
