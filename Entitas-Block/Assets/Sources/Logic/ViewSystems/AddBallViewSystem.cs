using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class AddBallViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    IGroup<GameEntity> _pointer;
    public AddBallViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _pointer = _contexts.game.GetGroup(GameMatcher.Pointer);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameobject = Object.Instantiate(_contexts.game.globals.value.ballPrefab);

            var ballEntity = _contexts.game.CreateEntity();
            ballEntity.isBall = true;
            ballEntity.AddPosition(new Vector2(rotate(Vector2.right * 2, entity.direction.angle * Mathf.Deg2Rad).x + _pointer.GetSingleEntity().position.value.x, rotate(Vector2.right * 2, entity.direction.angle * Mathf.Deg2Rad).y + _pointer.GetSingleEntity().position.value.y));
            ballEntity.AddPrefab(gameobject);
            ballEntity.AddBallMovement(8);
            ballEntity.AddDamage(1);
            gameobject.Link(ballEntity);

            //DrawLine(new Vector2(0, -(Screen.height / 200)), new Vector2(rotate(Vector2.right * 2, entity.direction.angle * Mathf.Deg2Rad).x, 
            //    rotate(Vector2.right * 2, entity.direction.angle * Mathf.Deg2Rad).y - (Screen.height / 200)), Color.white, 0.5f); 
            if (ballEntity.hasPosition)
            {
                gameobject.transform.position = ballEntity.position.value;
            }
            Rigidbody2D _rigidbody = gameobject.GetComponent<Rigidbody2D>();
            float x = Mathf.Cos(entity.direction.angle * Mathf.PI / 180) * 100 * ballEntity.ballMovement.speed;
            float y = Mathf.Sin(entity.direction.angle * Mathf.PI / 180) * 100 * ballEntity.ballMovement.speed;
            _rigidbody.AddForce(new Vector3(x, y, 0));
            entity.isDestroy = true;
        }
    }

    public static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }

    //void DrawLine(Vector2 start, Vector2 end, Color color, float duration)
    //{
    //    GameObject myLine = new GameObject();
    //    myLine.transform.position = start;
    //    myLine.AddComponent<LineRenderer>();
    //    LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //    lr.startColor = color;
    //    lr.endColor = Color.white;
    //    lr.startWidth = 0.3f;
    //    lr.endWidth = 0.3f;
    //    lr.SetPosition(0, start);
    //    lr.SetPosition(1, end);
    //    GameObject.Destroy(myLine, duration);
    //}

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSpawnBall && entity.hasDirection;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.SpawnBall, GameMatcher.Direction));
    }
}
