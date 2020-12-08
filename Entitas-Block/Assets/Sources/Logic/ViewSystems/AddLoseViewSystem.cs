using Entitas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas.Unity;

public class AddLoseViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public AddLoseViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameobject = Object.Instantiate(_contexts.game.globals.value.loseScreenPrefab, _contexts.game.uIRoot.value);

            entity.AddPosition(new Vector2(0, 0));
            entity.AddPrefab(gameobject);
            gameobject.GetComponentInChildren<Button>().onClick.AddListener(OnClickRestart);
            gameobject.Link(entity);

            if (entity.hasPosition)
            {
                gameobject.transform.position = entity.position.value;
            }
        }
    }

    public void OnClickRestart()
    {
        Contexts contexts = Contexts.sharedInstance;
        contexts.game.CreateEntity().isRestart = true;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isLoseScreen;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoseScreen);
    }
}
