using TMPro;
using UnityEngine;
public class GameSavedInfo : MonoBehaviour
{
    private float time;
    void Update()
    {
        if (gameObject.GetComponent<TextMeshProUGUI>().enabled)
        {
            time += Time.deltaTime;
            if (time > 2f)
            {
                gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
                time = 0f;
            }
        }
    }
}
