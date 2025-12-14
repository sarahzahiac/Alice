using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip newMusic;

    void Start()
    {
        musicSource.clip = newMusic;
        musicSource.Play();
    }
}
