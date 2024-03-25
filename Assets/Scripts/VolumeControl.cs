using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        

        
    }

    void ChangeVolume(float volume)
    {
        
        audioSource.volume = volume;
    }
}