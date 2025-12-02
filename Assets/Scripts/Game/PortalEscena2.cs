using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEscena2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate que el jugador tiene tag "Player"
        {
            SceneManager.LoadScene("Escena2");
        }
    }
}

