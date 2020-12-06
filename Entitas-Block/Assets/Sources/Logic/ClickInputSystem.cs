using Entitas;
using UnityEngine;

public class ClickInputSystem : IExecuteSystem
{
    private Contexts _contexts;
    public ClickInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetAxis("Mouse X") != 0 || (Input.GetAxis("Mouse Y") != 0))
        {
            var entity = _contexts.game.CreateEntity();
            entity.AddPosition(Input.mousePosition);
            entity.isMoveInput = true;
        }
    }
}
