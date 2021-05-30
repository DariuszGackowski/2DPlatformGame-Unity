using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    public Text text;
    private float time;
    private int randomNumber;
    private bool quickHideMouse;
    private void Start()
    {
        slider.value = 0f;
        text.text = "0 %";
        randomNumber = Random.Range(1, 5);
    }
    private void Update()
    {
        if (!quickHideMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            quickHideMouse = true;
        }
        time += Time.deltaTime;
        LoadingWay(randomNumber);
        if (slider.value == 1f)
            switch (ChoosenLevelContainer.choiceNumber)
            {
                case 1:
                    SceneManager.LoadScene("Standard");
                    break;
                case 2:
                    SceneManager.LoadScene("Boss'sOffice");
                    break;
                case 3:
                    SceneManager.LoadScene("CaveOfExtinction");
                    break;
                case 4:
                    SceneManager.LoadScene("FallenBridges");
                    break;
            }
    }
    private void LoadingWay(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                if (time > 0.5f & time < 1f)
                {
                    slider.value = 0.29f;
                    text.text = "29 %";
                }
                else if (time > 1f & time < 1.3f)
                {
                    slider.value = 0.47f;
                    text.text = "47 %";
                }
                else if (time > 1.3f & time < 2f)
                {
                    slider.value = 0.71f;
                    text.text = "71 %";
                }
                else if (time > 2f)
                {
                    slider.value = 1f;
                    text.text = "100 %";
                }
                break;
            case 2:
                if (time > 0.25f & time < 0.7f)
                {
                    slider.value = 0.12f;
                    text.text = "12 %";
                }
                else if (time > 0.7f & time < 1f)
                {
                    slider.value = 0.58f;
                    text.text = "58 %";
                }
                else if (time > 1f & time < 1.5f)
                {
                    slider.value = 0.79f;
                    text.text = "79 %";
                }
                else if (time > 1.5f)
                {
                    slider.value = 1f;
                    text.text = "100 %";
                }
                break;
            case 3:
                if (time > 0.7f & time < 1f)
                {
                    slider.value = 0.43f;
                    text.text = "43 %";
                }
                else if (time > 1f & time < 1.5f)
                {
                    slider.value = 0.61f;
                    text.text = "61 %";
                }
                else if (time > 1.5f)
                {
                    slider.value = 1f;
                    text.text = "100 %";
                }
                break;
            case 4:
                if (time > 0.5f & time < 0.7f)
                {
                    slider.value = 0.27f;
                    text.text = "27 %";
                }
                else if (time > 0.7f & time < 1f)
                {
                    slider.value = 0.55f;
                    text.text = "55 %";
                }
                else if (time > 1f)
                {
                    slider.value = 1f;
                    text.text = "100 %";
                }
                break;
        }
    }
}
