//using TMPro;
//using UnityEngine;

//public class LastTimerDisplay : MonoBehaviour
//{
//    // Rendre le champ priv�, car nous allons r�cup�rer le texte via le nom du GameObject
//    private TextMeshProUGUI lastTimerText;

//    void Start()
//    {
//        // R�cup�rer le TextMeshProUGUI par son nom dans la sc�ne
//        lastTimerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

//        if (lastTimerText != null)
//        {
//            // R�cup�rer la derni�re valeur du timer sauvegard�e
//            int lastTimeInSeconds = PlayerPrefs.GetInt("LastTimerValue", 0); // Valeur par d�faut � 0 si non trouv�e

//            // Convertir les secondes en minutes et secondes
//            int minutes = lastTimeInSeconds / 60;
//            int seconds = lastTimeInSeconds % 60;

//            // Afficher la derni�re valeur dans le texte
//            lastTimerText.text = "Derni�re Valeur : " + minutes + " minutes et " + seconds + " secondes";
//        }
//        else
//        {
//            Debug.LogError("Le texte TimerText n'a pas �t� trouv� dans la sc�ne.");
//        }
//    }
//}
