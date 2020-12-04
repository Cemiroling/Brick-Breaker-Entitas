using Entitas;
using UnityEngine;

public class InitializePointerSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitializePointerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {      
        var entity = _contexts.game.CreateEntity();
        entity.AddPosition(new Vector2(0, -Screen.height/200 + Screen.height / 1700f));
        entity.isPointer = true;
    }
}
