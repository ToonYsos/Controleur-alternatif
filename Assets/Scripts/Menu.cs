using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // N�cessaire pour les �l�ments UI

public class Menu : MonoBehaviour
{
    public Button playButton; // Bouton pour "Jouer"
    public Button quitButton; // Bouton pour "Quitter"

    private void Start()
    {
        // D�finit la r�solution de l'�cran
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);

        // Ajouter des listeners pour les boutons
        playButton.onClick.AddListener(PlayGame); // Appelle la fonction PlayGame() lors du clic sur le bouton
        quitButton.onClick.AddListener(QuitGame); // Appelle la fonction QuitGame() lors du clic sur le bouton
    }

    // Fonction appel�e lors du clic sur le bouton "Jouer"
    void PlayGame()
    {
        SceneManager.LoadScene("Rythme"); // Charge la sc�ne "Game"
    }

    // Fonction appel�e lors du clic sur le bouton "Quitter"
    void QuitGame()
    {
        Application.Quit(); // Quitte le jeu
        Debug.Log("Jeu quitt� !"); // Debug pour s'assurer que �a fonctionne dans l'�diteur, car Application.Quit ne fonctionne pas dans l'�diteur.
    }
}