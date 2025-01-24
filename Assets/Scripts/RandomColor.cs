using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;

    public float changeDelay = 2f; // Temps avant que le cube change automatiquement de couleur

    public KeyCode blackKey = KeyCode.LeftArrow, blueKey = KeyCode.B, greenKey = KeyCode.C,
                   greyKey = KeyCode.D, orangeKey = KeyCode.E, blue2Key = KeyCode.F,
                   purpleKey = KeyCode.G, redKey = KeyCode.H, yellowKey = KeyCode.I,
                   whiteKey = KeyCode.J;

    public Color black, blue, green, grey, orange, blue_2, purple, red, yellow, white;

    private Color currentColor;
    private int colorValue;
    [SerializeField] private bool keyPressed = false;

    // Référence publique pour le dossier GameOver
    public GameObject gameOverPanel;

    // Propriété publique pour accéder à keyPressed
    public bool KeyPressed => keyPressed;

    void Start()
    {
        if (healthBar == null)
        {
            Debug.LogError("La référence healthBar n'est pas assignée dans l'inspecteur !");
        }
        else
        {
            UpdateHealthBar();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);  // Désactive le panneau GameOver au départ
        }

        ChangeCubeColor();
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(blackKey))
        {
            if (colorValue == 1) HandleCorrectKeyPress("Noir");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(blueKey))
        {
            if (colorValue == 2) HandleCorrectKeyPress("Bleu");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(greenKey))
        {
            if (colorValue == 3) HandleCorrectKeyPress("Vert");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(greyKey))
        {
            if (colorValue == 4) HandleCorrectKeyPress("Gris");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(orangeKey))
        {
            if (colorValue == 5) HandleCorrectKeyPress("Orange");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(blue2Key))
        {
            if (colorValue == 6) HandleCorrectKeyPress("Bleu clair");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(purpleKey))
        {
            if (colorValue == 7) HandleCorrectKeyPress("Violet");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(redKey))
        {
            if (colorValue == 8) HandleCorrectKeyPress("Rouge");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(yellowKey))
        {
            if (colorValue == 9) HandleCorrectKeyPress("Jaune");
            else HandleWrongKeyPress();
        }
        else if (Input.GetKeyDown(whiteKey))
        {
            if (colorValue == 10) HandleCorrectKeyPress("Blanc");
            else HandleWrongKeyPress();
        }
    }

    void HandleCorrectKeyPress(string colorName)
    {
        keyPressed = true;
        GainLife(1);
        ChangeCubeColor();
    }

    void HandleWrongKeyPress()
    {
        keyPressed = true;
        LoseLife(10);
        ChangeCubeColor();
    }

    void ChangeCubeColor()
    {
        StopAllCoroutines();

        // Diminue le temps de délai après chaque changement de couleur
        changeDelay = Mathf.Max(2f, changeDelay - 0.25f); // Assure que changeDelay ne descende pas en dessous de 2 secondes

        Color[] colors = { black, blue, green, grey, orange, blue_2, purple, red, yellow, white };
        int randomColorIndex = Random.Range(0, colors.Length);
        currentColor = colors[randomColorIndex];
        colorValue = randomColorIndex + 1;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = currentColor;
        }
        else
        {
            Debug.LogError("Aucun Renderer trouvé sur l'objet !");
        }

        keyPressed = false;
        StartCoroutine(AutoChangeAfterDelay());
    }

    IEnumerator AutoChangeAfterDelay()
    {
        yield return new WaitForSeconds(changeDelay);

        if (!keyPressed)
        {
            Debug.Log("Aucune touche pressée à temps !");
            LoseLife(10);
        }

        ChangeCubeColor();
    }

    void LoseLife(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthBar();

        if (health <= 0)
        {
            ActivateGameOver();
        }
    }

    void GainLife(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = health / maxHealth;
        }
    }

    void ActivateGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // Active le dossier GameOver
            Time.timeScale = 0f;  // Met le jeu en pause
            Debug.Log("Game Over !");
        }
    }

    void DeactivateGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);  // Désactive le dossier GameOver
            Time.timeScale = 1f;  // Relance le jeu
        }
    }
}
