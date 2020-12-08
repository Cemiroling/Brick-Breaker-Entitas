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
                        if (block.position.value.y < Screen.height / 200f)
                            block.isViewable = true;
                        block.AddHealth(_contexts.game.gameData.value.blockStats.health);
                        block.AddBlockType(BlockType.SquareBlock);
                        block.AddScaleMultiplier(_contexts.game.gameData.value.blockStats.scale);
                        block.isBlock = true;
                        break;
                    case 2:
                        var bomb = _contexts.game.CreateEntity();
                        bomb.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        if (bomb.position.value.y < Screen.height / 200f)
                            bomb.isViewable = true;
                        bomb.AddHealth(_contexts.game.gameData.value.bombStats.health);
                        bomb.AddBlockType(BlockType.Bomb);
                        bomb.AddDamage(_contexts.game.gameData.value.bombStats.damage);
                        bomb.AddRadius(_contexts.game.gameData.value.bombStats.area);
                        bomb.AddScaleMultiplier(_contexts.game.gameData.value.bombStats.scale);
                        bomb.isBlock = true;
                        break;
                    case 3:
                        var laser = _contexts.game.CreateEntity();
                        laser.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        if (laser.position.value.y < Screen.height / 200f)
                            laser.isViewable = true;
                        laser.AddHealth(_contexts.game.gameData.value.laserStats.health);
                        laser.AddBlockType(BlockType.Laser);
                        laser.AddDamage(_contexts.game.gameData.value.laserStats.damage);
                        laser.AddLaserDirections(_contexts.game.gameData.value.laserStats.angles);
                        laser.AddRadius(_contexts.game.gameData.value.laserStats.range);
                        laser.AddScaleMultiplier(_contexts.game.gameData.value.laserStats.scale);
                        laser.isBlock = true;
                        break;
                    case 4:
                        var TLBlock = _contexts.game.CreateEntity();
                        TLBlock.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        if (TLBlock.position.value.y < Screen.height / 200f)
                            TLBlock.isViewable = true;
                        TLBlock.AddHealth(_contexts.game.gameData.value.blockStats.health);
                        TLBlock.AddBlockType(BlockType.TLTriangleBlock);
                        TLBlock.AddScaleMultiplier(_contexts.game.gameData.value.blockStats.scale);
                        TLBlock.isBlock = true;
                        break;
                    case 5:
                        var TRBlock = _contexts.game.CreateEntity();
                        TRBlock.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        if (TRBlock.position.value.y < Screen.height / 200f)
                            TRBlock.isViewable = true;
                        TRBlock.AddHealth(_contexts.game.gameData.value.blockStats.health);
                        TRBlock.AddBlockType(BlockType.TRTriangleBlock);
                        TRBlock.AddScaleMultiplier(_contexts.game.gameData.value.blockStats.scale);
                        TRBlock.isBlock = true;
                        break;
                    case 6:
                        var BRBlock = _contexts.game.CreateEntity();
                        BRBlock.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        if (BRBlock.position.value.y < Screen.height / 200f)
                            BRBlock.isViewable = true;
                        BRBlock.AddHealth(_contexts.game.gameData.value.blockStats.health);
                        BRBlock.AddBlockType(BlockType.BRTriangleBlock);
                        BRBlock.AddScaleMultiplier(_contexts.game.gameData.value.blockStats.scale);
                        BRBlock.isBlock = true;
                        break;
                    case 7:
                        var BLBlock = _contexts.game.CreateEntity();
                        BLBlock.AddPosition(new Vector2(j - 4.5f, i + 0.5f + Screen.height / 200f - _contexts.game.gameData.value.visibleArea));
                        if (BLBlock.position.value.y < Screen.height / 200f)
                            BLBlock.isViewable = true;
                        BLBlock.AddHealth(_contexts.game.gameData.value.blockStats.health);
                        BLBlock.AddBlockType(BlockType.BLTriangleBlock);
                        BLBlock.AddScaleMultiplier(_contexts.game.gameData.value.blockStats.scale);
                        BLBlock.isBlock = true;
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
