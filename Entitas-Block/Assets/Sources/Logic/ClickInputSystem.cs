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
            //Vector2 startPoint = new Vector2(0, -Screen.height/200);
            //Vector2 _mousePos = Input.mousePosition;
            //_mousePos.x = _mousePos.x - Camera.main.WorldToScreenPoint(startPoint).x;
            //_mousePos.y = _mousePos.y - Camera.main.WorldToScreenPoint(startPoint).y;          

            //entity.AddPosition(new Vector2((Input.mousePosition.x - Screen.width / 2) / 100, (Input.mousePosition.y - Screen.height / 2) / 100));
            entity.AddPosition(Input.mousePosition);
            entity.isMoveInput = true;
            //entity.AddDirection(Mathf.Clamp((Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg), 10f, 170f));
        }
    }
}
