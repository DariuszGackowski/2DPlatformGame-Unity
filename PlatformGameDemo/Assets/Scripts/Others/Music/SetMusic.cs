using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetMusic : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volume;
    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20f);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        PlayerPrefs.Save();
    }
}
