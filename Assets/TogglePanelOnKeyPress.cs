using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanelAndSliderOnButtonClick : MonoBehaviour
{
    public GameObject panel;            // Référence au Panel à activer/désactiver
    public Slider slider;               // Référence à la Slider Bar à activer/désactiver
    public Button toggleButton;         // Le bouton qui va activer/désactiver le Panel et la Slider
    public AudioSource musicSource;     // Référence à l'AudioSource pour la musique

    public Image settingsImage;         // Référence à l'image des paramètres
    public Button keyboardModeButton;   // Bouton pour activer/désactiver le mode clavier
    public Image blackFont;             // Fond noir

    public GameObject folder;           // Référence au dossier (objet parent contenant d'autres éléments)
    private bool isFolderActive = false; // État du dossier

    private bool isGamePaused = false;  // Variable pour savoir si le jeu est en pause ou non
    private bool isKeyboardModeActive = false; // Variable pour l'état du mode clavier

    void Start()
    {
        // Reliez les boutons aux méthodes appropriées
        toggleButton.onClick.AddListener(TogglePanelAndSlider);
        keyboardModeButton.onClick.AddListener(ToggleKeyboardMode);

        // Vérifier si la musique est déjà assignée
        if (musicSource == null)
        {
            musicSource = Camera.main.GetComponent<AudioSource>();
        }

        // Désactiver initialement tous les éléments
        DeactivateAllUI();
    }

    void Update()
    {
        // Vérifie si la touche Échap est pressée
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleFolderState();
        }
    }

    // Désactive tous les éléments au démarrage
    private void DeactivateAllUI()
    {
        if (panel != null) panel.SetActive(false);
        if (slider != null) slider.gameObject.SetActive(false);
        if (settingsImage != null) settingsImage.gameObject.SetActive(false);
        if (blackFont != null) blackFont.gameObject.SetActive(false);
        if (keyboardModeButton != null) keyboardModeButton.gameObject.SetActive(false);
        if (folder != null) folder.SetActive(false);
    }

    // Méthode pour activer/désactiver le panel et les éléments associés
    void TogglePanelAndSlider()
    {
        bool isPanelActive = panel.activeSelf;
        panel.SetActive(!isPanelActive);

        slider.gameObject.SetActive(!slider.gameObject.activeSelf);

        if (panel.activeSelf || slider.gameObject.activeSelf)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }

        if (settingsImage != null) settingsImage.gameObject.SetActive(!isPanelActive);

        SyncKeyboardUIState();
    }

    // Méthode pour activer/désactiver le mode clavier
    void ToggleKeyboardMode()
    {
        isKeyboardModeActive = !isKeyboardModeActive;

        if (blackFont != null)
        {
            blackFont.gameObject.SetActive(isKeyboardModeActive);
        }

        if (keyboardModeButton != null)
        {
            TextMeshProUGUI buttonText = keyboardModeButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = isKeyboardModeActive ? "Mode Clavier : Activé" : "Mode Clavier : Désactivé";
            }
        }

        Debug.Log("Mode clavier activé : " + isKeyboardModeActive);
    }

    // Méthode pour activer/désactiver le dossier
    void ToggleFolderState()
    {
        if (folder != null)
        {
            isFolderActive = !isFolderActive;
            folder.SetActive(isFolderActive);

            if (isFolderActive)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }

            Debug.Log("État du dossier : " + (isFolderActive ? "Activé" : "Désactivé"));
        }
    }

    // Réactive ou désactive les éléments liés au clavier en fonction de l'état du panel
    private void SyncKeyboardUIState()
    {
        if (panel.activeSelf)
        {
            if (blackFont != null) blackFont.gameObject.SetActive(true);
            if (keyboardModeButton != null) keyboardModeButton.gameObject.SetActive(true);
        }
        else
        {
            if (blackFont != null) blackFont.gameObject.SetActive(false);
            if (keyboardModeButton != null) keyboardModeButton.gameObject.SetActive(false);
        }
    }

    // Met en pause le jeu
    void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;

        if (musicSource != null)
        {
            musicSource.Pause();
        }

        Debug.Log("Jeu en pause");
    }

    // Reprendre le jeu
    void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;

        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }

        Debug.Log("Jeu repris");
    }
}
