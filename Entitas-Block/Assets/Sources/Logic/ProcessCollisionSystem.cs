using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCollisionSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> _blockGroup; 
    private IGroup<GameEntity> _pointerGroup;
    public ProcessCollisionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _blockGroup = _contexts.game.GetGroup(GameMatcher.Block);
        _pointerGroup = _contexts.game.GetGroup(GameMatcher.Pointer);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.collision.self.isBlock)
            {
                if (entity.collision.self.blockType.type == BlockType.SquareBlock)
                {
                    if (entity.collision.other.isBall)
                    {
                        entity.collision.self.health.value -= entity.collision.other.damage.value;
                        entity.collision.self.text.value.text = entity.collision.self.health.value.ToString();
                        if (entity.collision.self.health.value <= 0)
                        {
                            entity.collision.self.isDestroy = true;
                        }
                    }
                }
                if (entity.collision.self.blockType.type == BlockType.Bomb)
                {
                    entity.collision.self.health.value--;
                    entity.collision.self.text.value.text = entity.collision.self.health.value.ToString();
                    //foreach (var block in _blockGroup.GetEntities())
                    //{
                    //    if (block.blockType.type == BlockType.SquareBlock)
                    //    {
                    //        if ((block.position.value - entity.collision.self.position.value).sqrMagnitude <= entity.collision.self.radius.value * entity.collision.self.radius.value)
                    //        {
                    //            block.health.value -= entity.collision.self.damage.value;
                    //            block.text.value.text = block.health.value.ToString();
                    //            if (block.health.value <= 0)
                    //            {
                    //                block.isDestroy = true;
                    //            }
                    //        }
                    //    }
                    //}
                    Collider2D[] bombedBlocks = Physics2D.OverlapBoxAll(entity.collision.self.position.value, new Vector2(entity.collision.self.radius.value, entity.collision.self.radius.value), 0f);
                    foreach (var block in _blockGroup.GetEntities())
                    {
                        if (block.blockType.type == BlockType.SquareBlock)
                        {
                            foreach (Collider2D br in bombedBlocks)
                            {
                                if (GameObject.ReferenceEquals(block.prefab.prefab, br.gameObject))
                                {
                                    block.health.value -= entity.collision.self.damage.value;
                                    block.text.value.text = block.health.value.ToString();
                                    if (block.health.value <= 0)
                                    {
                                        block.isDestroy = true;
                                    }
                                }
                            }
                        }
                    }
                    if (entity.collision.self.health.value <= 0)
                    {
                        entity.collision.self.isDestroy = true;
                    }
                }
                if (entity.collision.self.blockType.type == BlockType.Laser)
                {
                    entity.collision.self.health.value--;
                    entity.collision.self.text.value.text = entity.collision.self.health.value.ToString();


                    foreach (float angle in entity.collision.self.laserDirections.angle)
                    {
                        Collider2D[] laseredBlocks = Physics2D.OverlapBoxAll(entity.collision.self.position.value, new Vector2(entity.collision.self.radius.value * 2, 0.3f), angle);
                        foreach (Collider2D br in laseredBlocks)
                        {
                            DrawLine(
                                new Vector2(rotate(Vector2.left * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).x + entity.collision.self.position.value.x,
                                            rotate(Vector2.left * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).y + entity.collision.self.position.value.y),
                                new Vector2(rotate(Vector2.right * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).x + entity.collision.self.position.value.x,
                                            rotate(Vector2.right * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).y + entity.collision.self.position.value.y),
                                            Color.red, 0.2f);
                            foreach (var block in _blockGroup.GetEntities())
                            {
                                if (block.blockType.type == BlockType.SquareBlock)
                                {
                                    if (GameObject.ReferenceEquals(block.prefab.prefab, br.gameObject))
                                    {
                                        block.health.value -= entity.collision.self.damage.value;
                                        block.text.value.text = block.health.value.ToString();
                                        if (block.health.value <= 0)
                                        {
                                            block.isDestroy = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (entity.collision.self.health.value <= 0)
                    {
                        entity.collision.self.isDestroy = true;
                    }
                }
            }
            if (entity.collision.self.isBoundary)
            {
                if (entity.collision.other.isBall)
                {                     
                    if(!_pointerGroup.GetSingleEntity().hasNewPointerPosition)
                    {
                        _pointerGroup.GetSingleEntity().AddNewPointerPosition(new Vector2(entity.collision.other.prefab.prefab.transform.position.x, _pointerGroup.GetSingleEntity().position.value.y));                       
                    }
                    entity.collision.other.isDestroy = true; 
                }
            }
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
    void DrawLine(Vector2 start, Vector2 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.startColor = color;
        lr.endColor = Color.white;
        lr.startWidth = 0.3f;
        lr.endWidth = 0.3f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }
}