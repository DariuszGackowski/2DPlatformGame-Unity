using Assets.Scripts.Important;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MainValuesContainer : MonoBehaviour
{
    public static List<TwoValues> orangeGems = new List<TwoValues>();
    public static List<TwoValues> blueGems = new List<TwoValues>();
    public static List<TwoValues> purpleGems = new List<TwoValues>();
    public static List<string> collectedGems = new List<string>();
    public static List<string> listOfReadyLevels = new List<string>();
    public static RigidbodyConstraints2D rigidbodyConstraints2DPlayer;
    public static bool unfrozeGame, pattern, checkLifePoints, selectedNumbersForLifePoints;
    public static int selectedOptionDeathScreen = 1, selectedOptionRestartScreen = 1, health, scorePurple, scoreOrange, scoreBlue, unlockedLevel = 1, chosenScene;
    private bool connectionWithMainValuesContainer = true;
    private void Update()
    {
        if (connectionWithMainValuesContainer)
        {
            gameObject.GetComponent<MainValuesContainerConnection>().enabled = true;
            connectionWithMainValuesContainer = false;
        }
    }
    public static bool CheckMyList(string nameOfLevel)
    {
        bool thisObjectIsOnList = false;
        foreach (string objectOnList in MainValuesContainer.listOfReadyLevels)
            thisObjectIsOnList = objectOnList == nameOfLevel ? true : thisObjectIsOnList;
        return thisObjectIsOnList;
    }
    public static void CheckingGemPoints(TextMeshProUGUI textMeshProUGUIOrange, TextMeshProUGUI textMeshProUGUIBlue, TextMeshProUGUI textMeshProUGUIPurple)
    {
        textMeshProUGUIOrange.text = "x" + MainValuesContainer.scoreOrange.ToString();
        textMeshProUGUIBlue.text = "x" + MainValuesContainer.scoreBlue.ToString();
        textMeshProUGUIPurple.text = "x" + MainValuesContainer.scorePurple.ToString();
    }
}
