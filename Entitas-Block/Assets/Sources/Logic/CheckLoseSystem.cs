using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class CheckLoseSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> _blockGroup;
    private IGroup<GameEntity> _pointerGroup;
    public CheckLoseSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _blockGroup = _contexts.game.GetGroup(GameMatcher.Block);
        _pointerGroup = _contexts.game.GetGroup(GameMatcher.Pointer);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isDestroy = true;

            foreach(var block in _blockGroup.GetEntities())
            {
                if (block.position.value.y < _pointerGroup.GetSingleEntity().position.value.y + 1 && block.blockType.type == BlockType.SquareBlock)
                {
                    var screen = _contexts.game.CreateEntity();
                    screen.isLoseScreen = true;
                    break;
                }           
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isCheckLose;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CheckLose);
    }
}