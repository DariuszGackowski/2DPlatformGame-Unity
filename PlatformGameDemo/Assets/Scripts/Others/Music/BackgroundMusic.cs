using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour
{
    public static bool muting;
    private GameObject[] musicObjects;
    public AudioMixer mixer;
    private float musicParameter, time, sliderValue, maxParameter;
    private readonly bool inDungeon;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            CheckingMusicSettings("Volume");
            CheckingMusicSettings("MusicVolume");
            CheckingMusicSettings("SoundsVolume");
        }
        musicObjects = GameObject.FindGameObjectsWithTag("Music");
        if (musicObjects.Length > 1)
            for (int i = 1; i < musicObjects.Length; i++)
                Destroy(musicObjects[i]);
        if (inDungeon)
            DestroyingSounds();
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (muting)
        {
            mixer.GetFloat("MusicVolume", out musicParameter);
            maxParameter = Mathf.Pow(10f, musicParameter / 20f);
            time += Time.deltaTime;
            if (time == 0.1f)
                Muting(3f * maxParameter / 4f);
            else if (time == 0.2f)
                Muting(2f * maxParameter / 4f);
            else if (time == 0.3f)
                Muting(maxParameter / 4f);
            else if (time == 0.4f)
                Muting(1f * maxParameter / 100f);
            else if (time > 0.5f)
                Invoke("DestroyingSounds", 0f);
        }
    }
    private void CheckingMusicSettings(string nameOfParameter)
    {
        sliderValue = PlayerPrefs.GetFloat(nameOfParameter);
        mixer.SetFloat(nameOfParameter, Mathf.Log10(sliderValue) * 20f);
    }
    private void Muting(float maxParameter)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(maxParameter) * 20f);
    }
    private void DestroyingSounds()
    {
        BackgroundMusic.muting = false;
        Destroy(gameObject);
    }
}
