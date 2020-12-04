using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class SetNewTurnSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> _blockGroup;
    public SetNewTurnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _blockGroup = _contexts.game.GetGroup(GameMatcher.Block);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            entity.isTimerEnd = false;

            var updatePointer = _contexts.game.CreateEntity();
            updatePointer.isSetNewPointerPosition = true;

            var moveBlocks = _contexts.game.CreateEntity();
            moveBlocks.isMoveBlock = true;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTimerEnd;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TimerEnd);
    }
}