using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class AddPointerViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Vector2 _dir;
    public AddPointerViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            IGroup<GameEntity> group = _contexts.game.GetGroup(GameMatcher.Pointer);
            foreach (var ent in group.GetEntities())
            {
                _dir.x = entity.position.value.x - Camera.main.WorldToScreenPoint(ent.position.value).x;
                _dir.y = entity.position.value.y - Camera.main.WorldToScreenPoint(ent.position.value).y;
                float angle = Mathf.Clamp((Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg), 10f, 170f);
                if (!ent.hasPrefab)
                {
                    var gameobject = Object.Instantiate(_contexts.game.globals.value.pointerPrefab);
                    gameobject.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                    ent.AddPrefab(gameobject);
                    gameobject.transform.position = ent.position.value;
                    gameobject.Link(ent);
                }
                else
                    ent.prefab.prefab.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            }
            entity.isDestroy = true;
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMoveInput && entity.hasPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.MoveInput, GameMatcher.Position));
    }
}