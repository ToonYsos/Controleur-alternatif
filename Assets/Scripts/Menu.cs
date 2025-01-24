using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Nécessaire pour les éléments UI

public class Menu : MonoBehaviour
{
    public Button playButton; // Bouton pour "Jouer"
    public Button quitButton; // Bouton pour "Quitter"

    private void Start()
    {
        // Définit la résolution de l'écran
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);

        // Ajouter des listeners pour les boutons
        playButton.onClick.AddListener(PlayGame); // Appelle la fonction PlayGame() lors du clic sur le bouton
        quitButton.onClick.AddListener(QuitGame); // Appelle la fonction QuitGame() lors du clic sur le bouton
    }

    // Fonction appelée lors du clic sur le bouton "Jouer"
    void PlayGame()
    {
        SceneManager.LoadScene("Rythme"); // Charge la scène "Game"
    }

    // Fonction appelée lors du clic sur le bouton "Quitter"
    void QuitGame()
    {
        Application.Quit(); // Quitte le jeu
        Debug.Log("Jeu quitté !"); // Debug pour s'assurer que ça fonctionne dans l'éditeur, car Application.Quit ne fonctionne pas dans l'éditeur.
    }
}