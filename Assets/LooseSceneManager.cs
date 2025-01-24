using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseSceneManager : MonoBehaviour
{
    // Cette m�thode sera appel�e lorsqu'on appuie sur le bouton "Play Again"
    public void PlayAgain()
    {
        Debug.Log("Play Again button clicked!");

        // Charger la sc�ne de jeu (remplacez "GameScene" par le nom r�el de votre sc�ne de jeu)
        SceneManager.LoadScene("Rythme");
    }

    // Cette m�thode sera appel�e si vous voulez ajouter un bouton pour quitter le jeu
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");
        Application.Quit(); // Quitte le jeu (ne fonctionne pas dans l'�diteur)
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
