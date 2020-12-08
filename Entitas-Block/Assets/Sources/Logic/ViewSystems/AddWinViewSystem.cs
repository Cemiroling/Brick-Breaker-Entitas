using Entitas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entitas.Unity;

public class AddWinViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public AddWinViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameobject = Object.Instantiate(_contexts.game.globals.value.winScreenPrefab, _contexts.game.uIRoot.value);

            entity.AddPosition(new Vector2(0, 0));
            entity.AddPrefab(gameobject);
            gameobject.Link(entity);

            //gameobject.GetComponentInChildren<Button>().onClick.AddListener(OnClickRestart);

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
        return entity.isWinScreen;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.WinScreen);
    }
}
