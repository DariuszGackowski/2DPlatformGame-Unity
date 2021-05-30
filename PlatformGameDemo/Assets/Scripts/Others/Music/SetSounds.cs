using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetSounds : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volume;
    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("SoundsVolume");
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("SoundsVolume", Mathf.Log10(sliderValue) * 20f);
        PlayerPrefs.SetFloat("SoundsVolume", sliderValue);
        PlayerPrefs.Save();
    }
}
