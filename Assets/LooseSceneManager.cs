using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseSceneManager : MonoBehaviour
{
    // Cette méthode sera appelée lorsqu'on appuie sur le bouton "Play Again"
    public void PlayAgain()
    {
        Debug.Log("Play Again button clicked!");

        // Charger la scène de jeu (remplacez "GameScene" par le nom réel de votre scène de jeu)
        SceneManager.LoadScene("Rythme");
    }

    // Cette méthode sera appelée si vous voulez ajouter un bouton pour quitter le jeu
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");
        Application.Quit(); // Quitte le jeu (ne fonctionne pas dans l'éditeur)
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
