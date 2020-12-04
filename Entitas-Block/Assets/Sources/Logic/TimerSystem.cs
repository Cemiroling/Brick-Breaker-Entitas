using Entitas;
using UnityEngine;

public class TimerSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _timerGroup;
    private IGroup<GameEntity> _ballGroup;
    private IGroup<GameEntity> _pointerGroup;
    private bool started;
    private bool test;
    private float delay;
    private float startingTime;
    private float spawningTime;
    private int currentIteration;
    private float direction;
    public TimerSystem(Contexts contexts)
    {
        _contexts = contexts;
        _timerGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.Iteration));
        _ballGroup = _contexts.game.GetGroup(GameMatcher.Ball);
        _pointerGroup = _contexts.game.GetGroup(GameMatcher.Pointer);
        started = false;
    }

    public void Execute()
    {
        if(_ballGroup.GetEntities().Length == 0 && test)
        {
            _timerGroup.GetSingleEntity().isTimerEnd = true;
            test = false;
        }   

        if (Input.GetMouseButtonDown(0) && _ballGroup.GetEntities().Length == 0)
        {
            startingTime = Time.time;
            spawningTime = startingTime; 
            
            Vector2 _mousePos = Input.mousePosition;
            _mousePos.x = _mousePos.x - Camera.main.WorldToScreenPoint(_pointerGroup.GetSingleEntity().position.value).x;
            _mousePos.y = _mousePos.y - Camera.main.WorldToScreenPoint(_pointerGroup.GetSingleEntity().position.value).y;           

            foreach (var ent in _timerGroup.GetEntities())
            {
                direction = (Mathf.Clamp((Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg), 10f, 170f));
                started = true;
                delay = ent.iteration.delay;               
                currentIteration = 0;
            }
        }
        if (started)
        {
            spawningTime = Time.time;
            if(spawningTime >= startingTime + delay * currentIteration)
            {             
                var entity = _contexts.game.CreateEntity();
                entity.isSpawnBall = true;
                entity.AddDirection(direction);

                currentIteration++;
                foreach (var ent in _timerGroup.GetEntities())
                {
                    if (currentIteration == ent.iteration.iterations)
                    {
                        started = false;
                        test = true;
                    }
                }              
            }
        }
    }
}
