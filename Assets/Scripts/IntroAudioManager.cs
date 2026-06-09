using UnityEngine;

public class IntroAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip start;

    private void Start()
    {
        audioSource.loop = true;
        audioSource.clip = start;
        audioSource.Play();
    }
}
