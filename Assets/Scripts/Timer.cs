using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // N�cessaire pour changer de sc�ne

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private int totalTimeInSeconds = 0;

    private IEnumerator StartTimer()
    {
        while (true)  // Boucle infinie pour que le timer continue ind�finiment
        {
            // Convertir les secondes en minutes et secondes
            int minutes = totalTimeInSeconds / 60;
            int seconds = totalTimeInSeconds % 60;

            // Mettre � jour le texte affich�
            timerText.text = minutes + " minutes and " + seconds + " seconds";

            yield return new WaitForSeconds(1);
            totalTimeInSeconds++;  // Incr�menter le temps en secondes
        }
    }

    void Start()
    {
        StartCoroutine(StartTimer());  // D�marrer le chronom�tre
    }

    // M�thode pour sauvegarder la derni�re valeur et changer de sc�ne
    public void SaveTimerAndSwitchScene(string nextSceneName)
    {
        // Sauvegarder la derni�re valeur dans PlayerPrefs
        PlayerPrefs.SetInt("LastTimerValue", totalTimeInSeconds);

        // Passer � la sc�ne suivante
        SceneManager.LoadScene(nextSceneName);
    }
}
