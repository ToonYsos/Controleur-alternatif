//using TMPro;
//using UnityEngine;

//public class LastTimerDisplay : MonoBehaviour
//{
//    // Rendre le champ privé, car nous allons récupérer le texte via le nom du GameObject
//    private TextMeshProUGUI lastTimerText;

//    void Start()
//    {
//        // Récupérer le TextMeshProUGUI par son nom dans la scène
//        lastTimerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

//        if (lastTimerText != null)
//        {
//            // Récupérer la dernière valeur du timer sauvegardée
//            int lastTimeInSeconds = PlayerPrefs.GetInt("LastTimerValue", 0); // Valeur par défaut à 0 si non trouvée

//            // Convertir les secondes en minutes et secondes
//            int minutes = lastTimeInSeconds / 60;
//            int seconds = lastTimeInSeconds % 60;

//            // Afficher la dernière valeur dans le texte
//            lastTimerText.text = "Dernière Valeur : " + minutes + " minutes et " + seconds + " secondes";
//        }
//        else
//        {
//            Debug.LogError("Le texte TimerText n'a pas été trouvé dans la scène.");
//        }
//    }
//}
