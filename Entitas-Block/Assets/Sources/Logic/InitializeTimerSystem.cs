using Entitas;
using UnityEngine;

public class InitializeTimerSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializeTimerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isTimer = true;
        entity.AddIteration(0.2f, 10);
    }
}
