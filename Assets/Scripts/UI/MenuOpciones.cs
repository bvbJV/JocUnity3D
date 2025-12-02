using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    [Header("UI")]
    public Toggle toggleMusica;
    public Button btnNivel1;
    public Button btnNivel2;
    public Button btnVolver;

    void Start()
    {
        // Inicializar estado del toggle desde PlayerPrefs (1 = on, 0 = off)
        int musicaOn = PlayerPrefs.GetInt("musica", 1);
        bool isOn = (musicaOn == 1);
        if (toggleMusica != null)
            toggleMusica.isOn = isOn;

        // Conectar eventos
        if (toggleMusica != null)
            toggleMusica.onValueChanged.AddListener(OnToggleMusica);

        if (btnNivel1 != null)
            btnNivel1.onClick.AddListener(JugarNivel1);

        if (btnNivel2 != null)
            btnNivel2.onClick.AddListener(JugarNivel2);

        if (btnVolver != null)
            btnVolver.onClick.AddListener(VolverMenuPrincipal);
    }

    void OnDestroy()
    {
        // Limpiar listeners para evitar duplicados al volver a entrar
        if (toggleMusica != null)
            toggleMusica.onValueChanged.RemoveListener(OnToggleMusica);
    }

    public void OnToggleMusica(bool isOn)
    {
        // Guardar en PlayerPrefs: 1 = on, 0 = off
        PlayerPrefs.SetInt("musica", isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Aplicarlo a la musica si existe un MusicManager en la escena
        MusicManager.Instance?.ApplyMusicPrefs();
    }

    public void JugarNivel1()
    {
        SceneManager.LoadScene("Escena1");
    }

    public void JugarNivel2()
    {
        SceneManager.LoadScene("Escena2");
    }

    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}

