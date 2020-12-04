using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class ChangePointerPositionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    IGroup<GameEntity> pointer;
    public ChangePointerPositionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        pointer = _contexts.game.GetGroup(GameMatcher.Pointer);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {      
            foreach (var ent in pointer.GetEntities())
            {
                ent.prefab.prefab.transform.position = ent.newPointerPosition.value;               
                ent.position.value = ent.newPointerPosition.value;
                ent.RemoveNewPointerPosition();
            }
            entity.isDestroy = true;
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSetNewPointerPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SetNewPointerPosition);
    }
}
