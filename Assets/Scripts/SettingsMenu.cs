using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    [Header(".............Audio Source...........")]
    [SerializeField] AudioSource musicSource;

    public void SetVolume (float volume)
    {
        Time.timeScale = 1;
        audioMixer.SetFloat("volume", volume);
    }

        public void SetSound (float volume)
    {
        audioMixer.SetFloat("volume", -80f);
    }

}