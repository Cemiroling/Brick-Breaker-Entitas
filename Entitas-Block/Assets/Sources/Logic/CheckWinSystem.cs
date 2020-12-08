using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> _blockGroup;
    public CheckWinSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _blockGroup = _contexts.game.GetGroup(GameMatcher.Block);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isDestroy = true;

            int blocksRemained = 0;
            foreach (var block in _blockGroup.GetEntities())
            {
                if (block.blockType.type == BlockType.SquareBlock ||
                    block.blockType.type == BlockType.TLTriangleBlock ||
                    block.blockType.type == BlockType.TRTriangleBlock ||
                    block.blockType.type == BlockType.BLTriangleBlock ||
                    block.blockType.type == BlockType.BRTriangleBlock)
                    blocksRemained++;
            }
            if (blocksRemained == 0)
            {
                var screen = _contexts.game.CreateEntity();
                screen.isWinScreen = true;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isCheckWin;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CheckWin);
    }
}