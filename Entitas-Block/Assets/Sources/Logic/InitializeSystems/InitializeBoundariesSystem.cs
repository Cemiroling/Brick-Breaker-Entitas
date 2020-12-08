using Entitas;
using UnityEngine;

public class InitializeBoundariesSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializeBoundariesSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        entity.isBoundary = true;
        entity.AddBoundaryType(BoundaryType.Top);

        var entity1 = _contexts.game.CreateEntity();
        entity1.isBoundary = true;
        entity1.AddBoundaryType(BoundaryType.Left);

        var entity2 = _contexts.game.CreateEntity();
        entity2.isBoundary = true;
        entity2.AddBoundaryType(BoundaryType.Right);

        var entity3 = _contexts.game.CreateEntity();
        entity3.isBoundary = true;
        entity3.AddBoundaryType(BoundaryType.Bottom);
    }
}
