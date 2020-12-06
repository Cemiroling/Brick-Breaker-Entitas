using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class JsonManager
{
    public static void Serialize(string fileName)
    {

        //int[,] _map =
        //{
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
        //    { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 }
        //};


        //int[,] _map =
        //{
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 4, 5, 6, 7, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        //};

        int[,] _map =
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 7, 7, 7, 7, 7, 7, 7, 7, 7, 0 },
            { 7, 6, 0, 0, 6, 0, 0, 5, 7, 0 },
            { 7, 0, 5, 0, 5, 0, 5, 0, 7, 0 },
            { 7, 0, 0, 4, 4, 4, 0, 0, 7, 0 },
            { 7, 6, 5, 4, 3, 4, 5, 6, 7, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        GameData gameData = new GameData();

        gameData.map = _map;
        gameData.ballsNumber = 12;
        gameData.visibleArea = 12;

        gameData.blockStats.health = 88;
        gameData.blockStats.scale = 1f;

        gameData.bombStats.health = 12;
        gameData.bombStats.area = 3;
        gameData.bombStats.damage = 1;
        gameData.bombStats.scale = 1;

        gameData.laserStats.health = 20;
        gameData.laserStats.range = 4;
        gameData.laserStats.damage = 1;
        gameData.laserStats.scale = 1;
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
