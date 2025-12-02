using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Collectibles")]
    public int totalCollectibles = 4;  // Número total de monedas
    private int collected = 0;

    [Header("Timer")]
    public float timeRemaining = 180f;  // 3 minutos
    private bool gameOver = false;

    [Header("UI")]
    public TMP_Text timeText;
    public TMP_Text collectibleText;
    public GameObject winPanel;
    public GameObject losePanel;

    void Awake()
    {
        // Singleton simple
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Asegurar que los paneles estén apagados
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        // Asegurar cursor bloqueado durante el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (gameOver) return;

        // Reducir tiempo
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            LoseGame();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timeText != null)
            timeText.text = "Tiempo: " + Mathf.CeilToInt(timeRemaining);

        if (collectibleText != null)
            collectibleText.text = "Objetos: " + collected + " / " + totalCollectibles;
    }

    public void AddCollectible()
    {
        collected++;

        if (collected >= totalCollectibles)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        gameOver = true;

        // Mostrar panel
        if (winPanel != null)
            winPanel.SetActive(true);

        // Desbloquear cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LoseGame()
    {
        gameOver = true;

        if (losePanel != null)
            losePanel.SetActive(true);

        // Desbloquear cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Botón para volver al menú principal
    public void VolverMenu()
    {
        // Asegurar cursor visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MenuPrincipal");
    }

    // Botón para reiniciar la escena actual
    public void Reintentar()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


