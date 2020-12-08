using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Systems _systems;
    public RestartSystem(Contexts contexts, Systems _system) : base(contexts.game)
    {
        _contexts = contexts;
        _systems = _system;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {   
            
            entity.isDestroy = true;
            foreach(var ent in _contexts.game.GetEntities())
            {
                ent.isDestroy = true;
            }
            _systems.Execute();
            _systems.TearDown();
            _systems.DeactivateReactiveSystems();
            _systems.ClearReactiveSystems();
            _contexts.Reset();
            SceneManager.LoadScene(0);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isRestart;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Restart);
    }
}