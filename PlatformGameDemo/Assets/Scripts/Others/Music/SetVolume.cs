using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider volume;
    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("Volume");
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20f);
        PlayerPrefs.SetFloat("Volume", sliderValue);
        PlayerPrefs.Save();
    }
}
