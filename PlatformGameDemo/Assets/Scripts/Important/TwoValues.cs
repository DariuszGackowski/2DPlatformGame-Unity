using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Important
{
    public class TwoValues
    {
        public string NameOfLevel { get; set; }
        public int NumberOfArea { get; set; }
        public TwoValues(int numberOfArea, string nameOfLavel)
        {
            this.NameOfLevel = nameOfLavel;
            this.NumberOfArea = numberOfArea;
        }
        public static void InscribeToMainList(List<TwoValues> mainList, List<int> list, string nameOfLevel)
        {
            foreach (int value in list)
                AddToMainList(mainList, value, nameOfLevel);
        }
        public static void AddToMainList(List<TwoValues> mainList, int valueFrommList, string nameOfLevel)
        {
            TwoValues twoValues = new TwoValues(valueFrommList, nameOfLevel);
            mainList.Add(twoValues);
        }
        public static void ExportFromMainList(List<TwoValues> mainList, int valueFromGem, string nameOfLevel, Color color, SpriteRenderer gemSprite)
        {
            foreach (var twoValues in mainList)
                gemSprite.color = nameOfLevel == twoValues.NameOfLevel & valueFromGem == twoValues.NumberOfArea ? color : gemSprite.color;
        }
    }
}

