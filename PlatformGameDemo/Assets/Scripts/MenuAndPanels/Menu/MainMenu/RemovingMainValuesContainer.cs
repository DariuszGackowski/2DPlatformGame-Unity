using UnityEngine;
public class RemovingMainValuesContainer : MonoBehaviour
{
    private GameObject mainValuesContainer;
    private void Start()
    {
        mainValuesContainer = GameObject.Find("/MainValuesContainer");
        if (mainValuesContainer != null)
        {
            MainValuesContainer.orangeGems.Clear();
            MainValuesContainer.blueGems.Clear();
            MainValuesContainer.purpleGems.Clear();
            MainValuesContainer.listOfReadyLevels.Clear();
            MainValuesContainer.unfrozeGame = MainValuesContainer.pattern = MainValuesContainer.checkLifePoints = MainValuesContainer.selectedNumbersForLifePoints = false;
            MainValuesContainer.selectedOptionDeathScreen = MainValuesContainer.selectedOptionRestartScreen = MainValuesContainer.unlockedLevel = 1;
            MainValuesContainer.health = 3;
            MainValuesContainer.scorePurple = MainValuesContainer.scoreOrange = MainValuesContainer.scoreBlue = MainValuesContainer.chosenScene = 0;
        }
    }
}
