using UnityEngine;

[DisallowMultipleComponent]
public class AutoTextureScroller : MonoBehaviour
{
    public float scrollX = 0.5f;
    public float scrollY = 0f;

    Renderer rend;
    Vector2 offset;
    string chosenProperty = null;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogError("AutoTextureScroller: no Renderer found on the GameObject.");
            enabled = false;
            return;
        }

        // Comprobamos propiedades comunes en shaders Built-in y URP
        string[] candidates = new string[] { "_BaseMap", "_MainTex" };

        foreach (var p in candidates)
        {
            if (rend.sharedMaterial != null && rend.sharedMaterial.HasProperty(p))
            {
                chosenProperty = p;
                break;
            }
        }

        if (chosenProperty == null)
        {
            // último recurso: si el material no reporta propiedades, lo notificamos
            Debug.LogWarning("AutoTextureScroller: no se encontró _BaseMap ni _MainTex en el material. Intentaré mainTextureOffset como fallback.");
        }
        else
        {
            Debug.Log("AutoTextureScroller: usando propiedad de textura: " + chosenProperty);
        }
    }

    void Update()
    {
        offset.x += scrollX * Time.deltaTime;
        offset.y += scrollY * Time.deltaTime;

        if (chosenProperty != null)
        {
            rend.material.SetTextureOffset(chosenProperty, offset);
        }
        else
        {
            // Fallback a la API legacy (puede funcionar en algunos shaders Built-in)
            rend.material.mainTextureOffset = offset;
        }
    }
}

