using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider; // Slider pour ajuster le volume

    void Start()
    {
        // Vérifier que le Slider est assigné
        if (volumeSlider == null)
        {
            Debug.LogError("VolumeSlider n'est pas assigné dans l'Inspector !");
            return;
        }

        // Charger le volume depuis PlayerPrefs ou initialiser par défaut
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f); // Volume par défaut
        }

        float savedVolume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = savedVolume; // Mettre à jour le Slider
        AudioListener.volume = savedVolume; // Appliquer le volume chargé

        // Ajouter un listener pour détecter les changements du Slider
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        // Appliquer le nouveau volume
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); // Sauvegarder
        Debug.Log("Volume mis à jour : " + volumeSlider.value);
    }
}
