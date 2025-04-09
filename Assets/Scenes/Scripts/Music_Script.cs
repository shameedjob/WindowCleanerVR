using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.volume = 0.1f; // Sets the percentage of the volume (Currently 10%)
        audioSource.Play();
        
        // Make persistent across scenes 
        DontDestroyOnLoad(gameObject);
    }
}