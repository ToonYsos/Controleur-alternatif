using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider; // Slider pour ajuster le volume

    void Start()
    {
        // V�rifier que le Slider est assign�
        if (volumeSlider == null)
        {
            Debug.LogError("VolumeSlider n'est pas assign� dans l'Inspector !");
            return;
        }

        // Charger le volume depuis PlayerPrefs ou initialiser par d�faut
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f); // Volume par d�faut
        }

        float savedVolume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = savedVolume; // Mettre � jour le Slider
        AudioListener.volume = savedVolume; // Appliquer le volume charg�

        // Ajouter un listener pour d�tecter les changements du Slider
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        // Appliquer le nouveau volume
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); // Sauvegarder
        Debug.Log("Volume mis � jour : " + volumeSlider.value);
    }
}
