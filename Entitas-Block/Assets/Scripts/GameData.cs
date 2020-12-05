using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class GameData
{
    public int[,] map;
    public struct BlockStats
    {
        public int health;
        public float scale;
    }
    public struct BombStats
    {
        public int health;
        public int damage;
        public int area;
        public float scale;
    }
    public struct LaserStats
    {
        public int health;
        public int damage;
        public int range;
        public float scale;
        public float[] angles;
    }

    public BlockStats blockStats;
    public BombStats bombStats;
    public LaserStats laserStats;

    public int ballsNumber;
    public int visibleArea;
}