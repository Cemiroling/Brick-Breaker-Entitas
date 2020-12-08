using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class JsonManager
{
    public static void Serialize(string fileName)
    {

        int[,] _map =
        {
            { 4, 1, 1, 1, 3, 3, 1, 1, 1, 4 },
            { 5, 1, 1, 1, 3, 3, 1, 1, 1, 5 },
            { 6, 1, 1, 1, 3, 3, 1, 1, 1, 6 },
            { 7, 1, 1, 1, 3, 3, 1, 1, 1, 7 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 3, 3, 1, 1, 1, 1 },
            { 1, 1, 2, 2, 3, 3, 2, 2, 1, 1 }
        };


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

        GameData gameData = new GameData();

        gameData.map = _map;
        gameData.ballsNumber = 10;
        gameData.visibleArea = 12;

        gameData.blockStats.health = 20;
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

        File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), ToJson);
    }

    public static GameData Deserialize(string fileName)
    {
        GameData gameData = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(Path.Combine(Application.persistentDataPath,fileName)));

        return gameData;
    }
}
