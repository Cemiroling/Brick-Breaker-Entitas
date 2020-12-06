using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEntitiesSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public DestroyEntitiesSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.hasPrefab)
            {
                var view = entity.prefab.prefab;
                view.Unlink();
                GameObject.Destroy(view);
            }
            if (entity.hasText)
            {
                GameObject.Destroy(entity.text.value.gameObject);
            }
            if (entity.hasLine)
            {
                foreach (var line in entity.line.lines)
                {
                    GameObject.Destroy(line.gameObject);
                }
            }
            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }
}
