using TMPro;
using UnityEngine;
public class GameLoadedInfo : MonoBehaviour
{
    public static bool gameIsLoaded;
    private float time;
    void Update()
    {
        if (GameLoadedInfo.gameIsLoaded)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            time += Time.deltaTime;
            if (time > 2f)
                GameLoadedInfo.gameIsLoaded = gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
            if (time != 0f)
            time = 0f;
    }
}
