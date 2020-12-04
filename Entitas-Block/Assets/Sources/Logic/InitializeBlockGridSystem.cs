using Entitas;
using UnityEngine;

public class InitializeBlockGridSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializeBlockGridSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        int rows = _contexts.game.gameData.value.map.GetUpperBound(0) + 1;
        int columns = _contexts.game.gameData.value.map.Length / rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                switch (_contexts.game.gameData.value.map[rows - 1 - i, j])
                {
                    case 1:
                        var block = _contexts.game.CreateEntity();
                        block.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        block.AddHealth(_contexts.game.gameData.value.blockStats.health);
                        block.AddBlockType(BlockType.SquareBlock);
                        block.isBlock = true;                    
                        break;
                    case 2:
                        var bomb = _contexts.game.CreateEntity();
                        bomb.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        bomb.AddHealth(_contexts.game.gameData.value.bombStats.health);
                        bomb.AddBlockType(BlockType.Bomb);
                        bomb.AddDamage(_contexts.game.gameData.value.bombStats.damage);
                        bomb.AddRadius(_contexts.game.gameData.value.bombStats.area);
                        bomb.isBlock = true;
                        break;
                    case 3:
                        var laser = _contexts.game.CreateEntity();
                        laser.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        laser.AddHealth(_contexts.game.gameData.value.laserStats.health);
                        laser.AddBlockType(BlockType.Laser);
                        laser.AddDamage(_contexts.game.gameData.value.laserStats.damage);
                        laser.AddLaserDirections(_contexts.game.gameData.value.laserStats.angles);
                        laser.AddRadius(_contexts.game.gameData.value.laserStats.range);
                        laser.isBlock = true;
                        break;
                }
            }
        }


        //for (int i = 0; i < 2; i++)
        //{
        //    for (int j = 0; j < 2; j++)
        //    {
        //        var block = _contexts.game.CreateEntity();
        //        block.AddPosition(new Vector2(j, i));
        //        block.AddHealth(10);
        //        block.AddBlockType(BlockType.SquareBlock);
        //        block.isBlock = true;
        //    }
        //}

        //var block1 = _contexts.game.CreateEntity();
        //block1.AddPosition(new Vector2(0, -3));
        //block1.AddHealth(10);
        //block1.AddBlockType(BlockType.SquareBlock);
        //block1.isBlock = true;

        //var block2 = _contexts.game.CreateEntity();
        //block2.AddPosition(new Vector2(0, -5));
        //block2.AddHealth(10);
        //block2.AddBlockType(BlockType.SquareBlock);
        //block2.isBlock = true;

        //var block3 = _contexts.game.CreateEntity();
        //block3.AddPosition(new Vector2(0, -7));
        //block3.AddHealth(10);
        //block3.AddBlockType(BlockType.SquareBlock);
        //block3.isBlock = true;

        //var bomb = _contexts.game.CreateEntity();
        //bomb.AddPosition(new Vector2(3, 1));
        //bomb.AddHealth(10);
        //bomb.AddBlockType(BlockType.Bomb);
        //bomb.AddDamage(2);
        //bomb.AddRadius(5);
        //bomb.isBlock = true;

        //var laser = _contexts.game.CreateEntity();
        //laser.AddPosition(new Vector2(3, 0));
        //laser.AddHealth(10);
        //laser.AddBlockType(BlockType.Laser);
        //laser.AddDamage(1);
        //laser.AddLaserDirections(new float[] {0, -45});
        //laser.AddRadius(4);
        //laser.isBlock = true;
    }
}
