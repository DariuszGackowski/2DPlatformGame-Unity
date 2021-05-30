using TMPro;
using UnityEngine;
public class LoadSavedTextButton : MonoBehaviour
{
    public int ownNumberOfOption;
    private string stringKey;
    private void Start()
    {
        stringKey = "TextInButton" + ownNumberOfOption.ToString();
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString(stringKey);
    }
}
