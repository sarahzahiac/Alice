using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource audioSource;   
    public AudioClip footstep;        
    public float delay = 0.25f;       

    float timer;

    void Update()
    {
        // On regarde si le joueur bouge vraiment
        float move = Mathf.Abs(Input.GetAxis("Vertical"));

        if (move > 0.1f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                audioSource.PlayOneShot(footstep);
                timer = delay;
            }
        }
        else
        {
            // Si le joueur s'arrête, on reset le timer
            timer = 0f;
        }
    }
}
