using TMPro;
using UnityEngine;
public class ChangingTextInButton : MonoBehaviour
{
    public static bool onSave;
    public SaveGameSelection saveGameSelection;
    public TextMeshProUGUI textMeshProUGUIInfo;
    public int ownNumberOfOption;
    private float timeToOverWriteTextMesh, timeWhenTextMeshAreFlashing;
    private string textString, startString, stringKey;
    private bool isChanged;
    private void Start()
    {
        stringKey = "TextInButton" + ownNumberOfOption.ToString();
        startString = PlayerPrefs.GetString(stringKey);
        gameObject.GetComponent<TextMeshProUGUI>().text = startString;
    }
    private void Update()
    {
        if (SaveGameSelection.selectedOption == ownNumberOfOption)
        {
            ChangingTextInButton.onSave = (timeToOverWriteTextMesh == 0f & ChangingTextInButton.onSave) ? false : ChangingTextInButton.onSave;
            if (timeToOverWriteTextMesh < 1.5f & !textMeshProUGUIInfo.enabled)
            {
                isChanged = SaveGameSelection.onMouseExit = ChangingTextInButton.onSave = false;
                timeToOverWriteTextMesh += Time.deltaTime;
            }
            if (timeToOverWriteTextMesh > 1.5f )
            {
                saveGameSelection.enabled = false;
                if (Input.GetKey(KeyCode.Escape) || SaveGameSelection.onMouseExit)
                {
                    gameObject.GetComponent<TextMeshProUGUI>().enabled = saveGameSelection.enabled = true;
                    gameObject.GetComponent<TextMeshProUGUI>().text = startString;
                    timeToOverWriteTextMesh = 0f;
                }
                if (ChangingTextInButton.onSave)
                {
                    gameObject.GetComponent<TextMeshProUGUI>().enabled = saveGameSelection.enabled = true;
                    textString = "";
                    startString = gameObject.GetComponent<TextMeshProUGUI>().text;
                    PlayerPrefs.SetString(stringKey, startString);
                    PlayerPrefs.Save();
                    timeToOverWriteTextMesh = 0f;
                }
                if (!Input.GetKey(KeyCode.Escape) & !Input.GetKey(KeyCode.Return) & !ChangingTextInButton.onSave & !SaveGameSelection.onMouseExit)
                {
                    timeWhenTextMeshAreFlashing += Time.deltaTime;
                    if (timeWhenTextMeshAreFlashing < 0.7f)
                        gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
                    else if (timeWhenTextMeshAreFlashing > 0.7f & timeWhenTextMeshAreFlashing < 1.4f)
                        gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
                    else if (timeWhenTextMeshAreFlashing > 1.4f)
                        timeWhenTextMeshAreFlashing = 0f;
                    if (!isChanged)
                        gameObject.GetComponent<TextMeshProUGUI>().text = "|";
                    else
                        OverWritingTextMesh(gameObject.GetComponent<TextMeshProUGUI>());
                }
            }
        }
        else if (SaveGameSelection.selectedOption != ownNumberOfOption)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            gameObject.GetComponent<TextMeshProUGUI>().text = startString;
            timeToOverWriteTextMesh = 0f;
        }
    }
    #region Writing
    private void OnGUI()
    {
        if (timeToOverWriteTextMesh > 1.5f)
        {
            if (!Input.GetKey(KeyCode.LeftShift) & Event.current.isKey & Event.current.keyCode.GetHashCode() >= 97 & Event.current.keyCode.GetHashCode() <= 122 & Event.current.type == EventType.KeyDown)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = gameObject.GetComponent<TextMeshProUGUI>().text == "|" ? "" : gameObject.GetComponent<TextMeshProUGUI>().text;
                textString = gameObject.GetComponent<TextMeshProUGUI>().text + Event.current.keyCode.ToString().ToLower();
                isChanged = true;
            }
            else if (!Input.GetKey(KeyCode.LeftShift) & Event.current.isKey & Event.current.keyCode.GetHashCode() >= 48 & Event.current.keyCode.GetHashCode() <= 57 & Event.current.type == EventType.KeyDown)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = gameObject.GetComponent<TextMeshProUGUI>().text == "|" ? "" : gameObject.GetComponent<TextMeshProUGUI>().text;
                char[] charArray = Event.current.keyCode.ToString().ToCharArray();
                textString = gameObject.GetComponent<TextMeshProUGUI>().text + charArray[5].ToString();
                isChanged = true;
            }
            else if (!Input.GetKey(KeyCode.LeftShift) & Event.current.isKey & Event.current.keyCode.GetHashCode() == 32 & Event.current.type == EventType.KeyDown)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = gameObject.GetComponent<TextMeshProUGUI>().text == "|" ? "" : gameObject.GetComponent<TextMeshProUGUI>().text;
                textString = gameObject.GetComponent<TextMeshProUGUI>().text + " ";
                isChanged = true;
            }
            else if (Input.GetKey(KeyCode.LeftShift) & Event.current.isKey & Event.current.keyCode.GetHashCode() >= 97 & Event.current.keyCode.GetHashCode() <= 122 & Event.current.type == EventType.KeyDown)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = gameObject.GetComponent<TextMeshProUGUI>().text == "|" ? "" : gameObject.GetComponent<TextMeshProUGUI>().text;
                textString = gameObject.GetComponent<TextMeshProUGUI>().text + Event.current.keyCode.ToString().ToUpper();
                isChanged = true;
            }
            else if (isChanged & Event.current.isKey & Event.current.keyCode.GetHashCode() == 8 & Event.current.type == EventType.KeyDown)
            {
                char[] charArray;
                charArray = gameObject.GetComponent<TextMeshProUGUI>().text.ToCharArray();
                textString = "";
                for (int j = 0; j < charArray.Length - 1; j++)
                {
                    textString += charArray[j].ToString();
                }
            }
        }
    }
    private void OverWritingTextMesh(TextMeshProUGUI textMeshProUGUI)
    {
        char[] charArray = textString.ToCharArray();
        string charString = "";
        if (charArray.Length > 10)
        {
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                charString += charArray[i].ToString();
            }
            textMeshProUGUI.text = charString;
        }
        else if (charArray.Length <= 10)
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                charString += charArray[i].ToString();
            }
            textMeshProUGUI.text = charString;
        }
        textMeshProUGUI.text = textString == "" ? "|" : textMeshProUGUI.text;
    }
    #endregion
}

