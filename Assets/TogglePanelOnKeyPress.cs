using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanelAndSliderOnButtonClick : MonoBehaviour
{
    public GameObject panel;            // R�f�rence au Panel � activer/d�sactiver
    public Slider slider;               // R�f�rence � la Slider Bar � activer/d�sactiver
    public Button toggleButton;         // Le bouton qui va activer/d�sactiver le Panel et la Slider
    public AudioSource musicSource;     // R�f�rence � l'AudioSource pour la musique

    public Image settingsImage;         // R�f�rence � l'image des param�tres
    public Button keyboardModeButton;   // Bouton pour activer/d�sactiver le mode clavier
    public Image blackFont;             // Fond noir

    public GameObject folder;           // R�f�rence au dossier (objet parent contenant d'autres �l�ments)
    private bool isFolderActive = false; // �tat du dossier

    private bool isGamePaused = false;  // Variable pour savoir si le jeu est en pause ou non
    private bool isKeyboardModeActive = false; // Variable pour l'�tat du mode clavier

    void Start()
    {
        // Reliez les boutons aux m�thodes appropri�es
        toggleButton.onClick.AddListener(TogglePanelAndSlider);
        keyboardModeButton.onClick.AddListener(ToggleKeyboardMode);

        // V�rifier si la musique est d�j� assign�e
        if (musicSource == null)
        {
            musicSource = Camera.main.GetComponent<AudioSource>();
        }

        // D�sactiver initialement tous les �l�ments
        DeactivateAllUI();
    }

    void Update()
    {
        // V�rifie si la touche �chap est press�e
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleFolderState();
        }
    }

    // D�sactive tous les �l�ments au d�marrage
    private void DeactivateAllUI()
    {
        if (panel != null) panel.SetActive(false);
        if (slider != null) slider.gameObject.SetActive(false);
        if (settingsImage != null) settingsImage.gameObject.SetActive(false);
        if (blackFont != null) blackFont.gameObject.SetActive(false);
        if (keyboardModeButton != null) keyboardModeButton.gameObject.SetActive(false);
        if (folder != null) folder.SetActive(false);
    }

    // M�thode pour activer/d�sactiver le panel et les �l�ments associ�s
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

    // M�thode pour activer/d�sactiver le mode clavier
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
                buttonText.text = isKeyboardModeActive ? "Mode Clavier : Activ�" : "Mode Clavier : D�sactiv�";
            }
        }

        Debug.Log("Mode clavier activ� : " + isKeyboardModeActive);
    }

    // M�thode pour activer/d�sactiver le dossier
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

            Debug.Log("�tat du dossier : " + (isFolderActive ? "Activ�" : "D�sactiv�"));
        }
    }

    // R�active ou d�sactive les �l�ments li�s au clavier en fonction de l'�tat du panel
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
