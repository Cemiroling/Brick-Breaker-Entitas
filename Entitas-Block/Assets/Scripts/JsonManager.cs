using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class JsonManager
{
    public static void Serialize(string fileName)
    {
        int[,] _map =
        {
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 1, 1, 0, 0, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 0, 0, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 0, 0, 1, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1, 1, 0, 0, 1, 1 },
            { 0, 0, 0, 0, 1, 1, 0, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 },
            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }
        };

        //int[,] _map =
        //{
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
        //    { 1, 1, 1, 1, 3, 1, 1, 1, 1, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        //};

        GameData gameData = new GameData();

        gameData.map = _map;
        gameData.ballsNumber = 10;
        gameData.visibleArea = 12;

        gameData.blockStats.health = 22;

        gameData.bombStats.health = 6;
        gameData.bombStats.area = 3;
        gameData.bombStats.damage = 1;

        gameData.laserStats.health = 20;
        gameData.laserStats.range = 3;
        gameData.laserStats.damage = 1;
        gameData.laserStats.angles = new float[] {45, -45, 0};

        string ToJson = JsonConvert.SerializeObject(gameData, Formatting.None);

        File.WriteAllText(Application.dataPath + "/" + fileName, ToJson);
    }

    public static GameData Deserialize(string fileName)
    {
        GameData gameData = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(Application.dataPath + "/" + fileName));

        return gameData;
    }
}
