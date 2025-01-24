using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private int totalTimeInSeconds = 0;

    private IEnumerator StartTimer()
    {
        while (true)  // Boucle infinie pour que le timer continue indéfiniment
        {
            // Convertir les secondes en minutes et secondes
            int minutes = totalTimeInSeconds / 60;
            int seconds = totalTimeInSeconds % 60;

            // Mettre à jour le texte affiché
            timerText.text = minutes + " minutes and " + seconds + " seconds";

            yield return new WaitForSeconds(1);
            totalTimeInSeconds++;  // Incrémenter le temps en secondes
        }
    }

    void Start()
    {
        StartCoroutine(StartTimer());  // Démarrer le chronomètre
    }

    // Méthode pour sauvegarder la dernière valeur et changer de scène
    public void SaveTimerAndSwitchScene(string nextSceneName)
    {
        // Sauvegarder la dernière valeur dans PlayerPrefs
        PlayerPrefs.SetInt("LastTimerValue", totalTimeInSeconds);

        // Passer à la scène suivante
        SceneManager.LoadScene(nextSceneName);
    }
}
