using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sonido al recoger
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Sumar al GameManager
            GameManager.instance.AddCollectible();

            // Desaparecer
            Destroy(gameObject);
        }
    }
}


