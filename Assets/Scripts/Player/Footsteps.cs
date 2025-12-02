using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepSource;
    public float stepSpeed = 0.45f;
    private float stepTimer = 0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0)
            {
                footstepSource.Play();
                stepTimer = stepSpeed;
            }
        }
    }
}

