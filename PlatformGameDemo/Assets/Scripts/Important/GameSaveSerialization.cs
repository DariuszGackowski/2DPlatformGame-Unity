using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Important
{
    public class GameSaveSerialization : ISerializable
    {
        public int OrangeGems { get; set; }
        public int BlueGems { get; set; }
        public int PurpleGems { get; set; }
        public int UnlockedLevel { get; set; }
        public int Life { get; set; }
        public string ReadyLevels { get; }
        public string OrangeList { get; }
        public string BlueList { get; }
        public string PurpleList { get; }

        public static List<GameSaveSerialization> gameSaveSerializationList = new List<GameSaveSerialization>();
        public GameSaveSerialization() { }
        public GameSaveSerialization(int orangeGems, int blueGems, int purpleGems, int level, int life, List<string> listOfTallLevels, List<TwoValues> orangeList, List<TwoValues> blueList, List<TwoValues> purpleList)
        {
            this.OrangeGems = orangeGems;
            this.BlueGems = blueGems;
            this.PurpleGems = purpleGems;
            this.UnlockedLevel = level;
            this.Life = life;
            ReadyLevels = ListToString(listOfTallLevels);
            OrangeList = MapToString(orangeList);
            BlueList = MapToString(blueList);
            PurpleList = MapToString(purpleList);
        }
        public string MapToString(List<TwoValues> someOwnMapList)
        {
            string someList = null;
            foreach (TwoValues someValues in someOwnMapList)
                someList += someValues.NumberOfArea.ToString() + someValues.NameOfLevel.ToString() + "|";
            return someList;
        }
        public string ListToString(List<string> listOfTallLevels)
        {
            string readyLevels = null;
            foreach (string objectInlistOfTallLevels in listOfTallLevels)
                readyLevels += objectInlistOfTallLevels.ToString() + "|";
            return readyLevels;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Orange Gems", OrangeGems);
            info.AddValue("Blue Gems", BlueGems);
            info.AddValue("Purple Gems", PurpleGems);
            info.AddValue("Level", UnlockedLevel);
            info.AddValue("Life ", Life);
            info.AddValue("Ready Levels", ReadyLevels);
            info.AddValue("OrangeList Value", OrangeList);
            info.AddValue("BlueList Value", BlueList);
            info.AddValue("PurpleList Value", PurpleList);
        }
        public GameSaveSerialization(SerializationInfo info, StreamingContext context)
        {
            OrangeGems = (int)info.GetValue("Orange Gems", typeof(int));
            BlueGems = (int)info.GetValue("Blue Gems", typeof(int));
            PurpleGems = (int)info.GetValue("Purple Gems", typeof(int));
            UnlockedLevel = (int)info.GetValue("Unlocked Level", typeof(int));
            Life = (int)info.GetValue("Life", typeof(int));
            ReadyLevels = (string)info.GetValue("Ready Levels", typeof(string));
            OrangeList = (string)info.GetValue("OrangeList Value", typeof(string));
            BlueList = (string)info.GetValue("BlueList Value", typeof(string));
            PurpleList = (string)info.GetValue("PurpleList Value", typeof(string));
        }
        public static void SaveToFile(int orangeGems, int blueGems, int purpleGems, int level, int life, List<string> listOfTallLevels, List<TwoValues> orangeList, List<TwoValues> blueList, List<TwoValues> purpleList, string nameOfButton)
        {
            GameSaveSerialization gameSaveSerialization = new GameSaveSerialization(orangeGems, blueGems, purpleGems, level, life, listOfTallLevels, orangeList, blueList, purpleList);
            GameSaveSerialization.gameSaveSerializationList.Add(gameSaveSerialization);
            using (Stream fs1 = new FileStream(@"..\SunnyLandDemo\SavedGames\" + nameOfButton + ".xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer1 = new XmlSerializer(typeof(List<GameSaveSerialization>));
                serializer1.Serialize(fs1, GameSaveSerialization.gameSaveSerializationList);
            }
            GameSaveSerialization.gameSaveSerializationList.Clear();
        }
        public static void LoadGame(string nameOfButton)
        {
            GameSaveSerialization.ReadFile(nameOfButton);
            MainValuesContainer.orangeGems.Clear();
            MainValuesContainer.blueGems.Clear();
            MainValuesContainer.purpleGems.Clear();
            MainValuesContainer.listOfReadyLevels.Clear();
            MainValuesContainer.unlockedLevel = MainValuesContainer.health = MainValuesContainer.scorePurple = MainValuesContainer.scoreBlue = MainValuesContainer.scoreOrange = 0;
            MainValuesContainer.orangeGems = GameSaveSerialization.ReadOrangeList();
            MainValuesContainer.blueGems = GameSaveSerialization.ReadBlueList();
            MainValuesContainer.purpleGems = GameSaveSerialization.ReadPurpleList();
            MainValuesContainer.scoreOrange = GameSaveSerialization.ReadOrangeGems();
            MainValuesContainer.scoreBlue = GameSaveSerialization.ReadBlueGems();
            MainValuesContainer.scorePurple = GameSaveSerialization.ReadPurpleGems();
            MainValuesContainer.health = GameSaveSerialization.ReadLife();
            MainValuesContainer.unlockedLevel = GameSaveSerialization.ReadLevel();
            MainValuesContainer.listOfReadyLevels = GameSaveSerialization.ReadReadyLevels();
            GameSaveSerialization.gameSaveSerializationList.Clear();
            SceneManager.LoadScene("Levels");
        }
        public static void ReadFile(string nameOfButton)
        {
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<GameSaveSerialization>));
            using (FileStream fs2 = File.OpenRead(@"..\SunnyLandDemo\SavedGames\" + nameOfButton + ".xml"))
            {
                GameSaveSerialization.gameSaveSerializationList = (List<GameSaveSerialization>)serializer2.Deserialize(fs2);
            }
        }
        public static List<string> ReadReadyLevels()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string pattern = @"([^|]+)";
            List<string> listOfLevels = new List<string>();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.ReadyLevels);
            MatchCollection matches = Regex.Matches(stringBuilder.ToString(), pattern);
            foreach (Match match in matches)
                listOfLevels.Add(match.ToString());
            return listOfLevels;
        }
        public static List<TwoValues> ReadOrangeList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string pattern = @"([^|]+)";
            Regex findingNameOfLevel = new Regex(@"(\D+)");
            Regex findingValues = new Regex(@"(\d+)");
            List<string> listOfValueAndName = new List<string>();
            List<TwoValues> listOfAllValuesWithNameOfLevel = new List<TwoValues>();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.OrangeList);
            MatchCollection matches = Regex.Matches(stringBuilder.ToString(), pattern);
            foreach (Match match in matches)
                listOfValueAndName.Add(match.ToString());
            foreach (string valueAndNameOfLevel in listOfValueAndName)
            {
                Match match2 = findingNameOfLevel.Match(valueAndNameOfLevel);
                Match match3 = findingValues.Match(valueAndNameOfLevel);
                TwoValues TwoValues = new TwoValues(int.Parse(match3.ToString()), match2.ToString());
                listOfAllValuesWithNameOfLevel.Add(TwoValues);
            }
            return listOfAllValuesWithNameOfLevel;
        }
        public static List<TwoValues> ReadBlueList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string pattern = @"([^|]+)";
            Regex findingNameOfLevel = new Regex(@"(\D+)");
            Regex findingValues = new Regex(@"(\d+)");
            List<string> listOfValueAndName = new List<string>();
            List<TwoValues> listOfAllValuesWithNameOfLevel = new List<TwoValues>();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.BlueList);
            MatchCollection matches = Regex.Matches(stringBuilder.ToString(), pattern);
            foreach (Match match in matches)
                listOfValueAndName.Add(match.ToString());
            foreach (string valueAndNameOfLevel in listOfValueAndName)
            {
                Match match2 = findingNameOfLevel.Match(valueAndNameOfLevel);
                Match match3 = findingValues.Match(valueAndNameOfLevel);
                TwoValues TwoValues = new TwoValues(int.Parse(match3.ToString()), match2.ToString());
                listOfAllValuesWithNameOfLevel.Add(TwoValues);
            }
            return listOfAllValuesWithNameOfLevel;
        }
        public static List<TwoValues> ReadPurpleList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string pattern = @"([^|]+)";
            Regex findingNameOfLevel = new Regex(@"(\D+)");
            Regex findingValues = new Regex(@"(\d+)");
            List<string> listOfValueAndName = new List<string>();
            List<TwoValues> listOfAllValuesWithNameOfLevel = new List<TwoValues>();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.PurpleList);
            MatchCollection matches = Regex.Matches(stringBuilder.ToString(), pattern);
            foreach (Match match in matches)
                listOfValueAndName.Add(match.ToString());
            foreach (string valueAndNameOfLevel in listOfValueAndName)
            {
                Match match2 = findingNameOfLevel.Match(valueAndNameOfLevel);
                Match match3 = findingValues.Match(valueAndNameOfLevel);
                TwoValues TwoValues = new TwoValues(int.Parse(match3.ToString()), match2.ToString());
                listOfAllValuesWithNameOfLevel.Add(TwoValues);
            }
            return listOfAllValuesWithNameOfLevel;
        }
        public static int ReadLife()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.Life);
            return int.Parse(stringBuilder.ToString());
        }
        public static int ReadLevel()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.UnlockedLevel);
            return int.Parse(stringBuilder.ToString());
        }
        public static int ReadOrangeGems()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.OrangeGems);
            return int.Parse(stringBuilder.ToString());
        }
        public static int ReadBlueGems()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.BlueGems);
            return int.Parse(stringBuilder.ToString());
        }
        public static int ReadPurpleGems()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (GameSaveSerialization s in GameSaveSerialization.gameSaveSerializationList)
                stringBuilder.Append(s.PurpleGems);
            return int.Parse(stringBuilder.ToString());
        }
    }
}

