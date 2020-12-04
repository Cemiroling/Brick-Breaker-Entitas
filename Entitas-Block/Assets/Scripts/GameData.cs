using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class GameData : IComponent
{
    public int[,] map;
    public struct BlockStats
    {
        public int health;
    }
    public struct BombStats
    {
        public int health;
        public int damage;
        public int area;
    }
    public struct LaserStats
    {
        public int health;
        public int damage;
        public int range;
        public float[] angles;
    }

    public BlockStats blockStats;
    public BombStats bombStats;
    public LaserStats laserStats;

    public int ballsNumber;
    public int visibleArea;
}