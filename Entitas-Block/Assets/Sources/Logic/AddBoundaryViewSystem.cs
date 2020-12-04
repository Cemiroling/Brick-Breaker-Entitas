using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class AddBoundaryViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public AddBoundaryViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameobject = Object.Instantiate(_contexts.game.globals.value.boundaryPrefab);

            if (entity.boundaryType.value == BoundaryType.Top)
            {
                entity.AddPosition(new Vector2(0, Screen.height / 200f));
                gameobject.transform.localScale = new Vector3(Screen.width / 100f, 0.3f, 0);
                gameobject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (entity.boundaryType.value == BoundaryType.Left)
            {
                entity.AddPosition(new Vector2(-Screen.width / 200f, 0));
                gameobject.transform.localScale = new Vector3(Screen.height / 100f, 0.3f, 0);
                gameobject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (entity.boundaryType.value == BoundaryType.Right)
            {
                entity.AddPosition(new Vector2(Screen.width / 200f, 0));
                gameobject.transform.localScale = new Vector3(Screen.height / 100f, 0.3f, 0);
                gameobject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                entity.AddPosition(new Vector2(0, -Screen.height / 200f + Screen.height / 2000));
                gameobject.transform.localScale = new Vector3(Screen.width / 100f, 2f, 0);
                gameobject.transform.rotation = Quaternion.Euler(0, 0, 0);
                System.Type MyScriptType = System.Type.GetType("CollisionEmitter,Assembly-CSharp");
                gameobject.AddComponent(MyScriptType);
            }
            entity.AddPrefab(gameobject);
            gameobject.Link(entity);

            if (entity.hasPosition)
            {
                gameobject.transform.position = entity.position.value;
            }
        }
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.isBoundary && entity.hasBoundaryType;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Boundary, GameMatcher.BoundaryType));
    }
}
