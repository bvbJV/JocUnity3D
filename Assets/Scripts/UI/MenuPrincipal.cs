using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void AbrirOpciones()
    {
        SceneManager.LoadScene("MenuOpciones");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado (solo visible en editor)");
    }
}

