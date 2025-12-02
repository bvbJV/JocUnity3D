using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject canvasPausa;
    private bool enPausa = false;

    void Update()
    {
        // Detecta ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (enPausa)
                Continuar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        enPausa = true;
        canvasPausa.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continuar()
    {
        enPausa = false;
        canvasPausa.SetActive(false);
        Time.timeScale = 1f; // Reanuda el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IrMenuPrincipal()
    {
        Time.timeScale = 1f; // Por si vuelves desde pausa
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Salir()
    {
        Application.Quit();

        // Solo para ver el mensaje en el editor
        Debug.Log("El juego se ha cerrado");
    }
}

