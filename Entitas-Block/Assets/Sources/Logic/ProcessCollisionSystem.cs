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
        _blockGroup = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Block, GameMatcher.Viewable));
        _pointerGroup = _contexts.game.GetGroup(GameMatcher.Pointer);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.collision.self.isBlock)
            {
                if (entity.collision.self.blockType.type == BlockType.SquareBlock ||
                    entity.collision.self.blockType.type == BlockType.BRTriangleBlock ||
                    entity.collision.self.blockType.type == BlockType.TRTriangleBlock ||
                    entity.collision.self.blockType.type == BlockType.BLTriangleBlock ||
                    entity.collision.self.blockType.type == BlockType.TLTriangleBlock)
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
                    Vector2 pointPos;

                    foreach (var block in _blockGroup.GetEntities())
                    {
                        if (block.blockType.type == BlockType.SquareBlock)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                //DrawLine(new Vector2(entity.collision.self.position.value.x, entity.collision.self.position.value.y),
                                //    new Vector2(entity.collision.self.position.value.x - entity.collision.self.radius.value - 0.5f + ((entity.collision.self.radius.value + 0.5f) * 2) * (i / 2),
                                //    entity.collision.self.position.value.y - entity.collision.self.radius.value - 0.5f + ((entity.collision.self.radius.value + 0.5f) * 2) * (i % 2)),
                                //    Color.white, 0.5f);
                                pointPos = new Vector2(block.scaleMultiplier.value * (i % 2 - 0.5f), block.scaleMultiplier.value * (i / 2 - 0.5f));

                                if ((entity.collision.self.position.value.x - 0.5f - entity.collision.self.radius.value
                                    < block.position.value.x + pointPos.x && block.position.value.x + pointPos.x
                                    < entity.collision.self.position.value.x + 0.5f + entity.collision.self.radius.value) &&
                                    (entity.collision.self.position.value.y - 0.5f - entity.collision.self.radius.value
                                    < block.position.value.y + pointPos.y && block.position.value.y + pointPos.y
                                    < entity.collision.self.position.value.y + 0.5f + entity.collision.self.radius.value))
                                {
                                    block.health.value -= entity.collision.self.damage.value;
                                    block.text.value.text = block.health.value.ToString();
                                    if (block.health.value <= 0)
                                    {
                                        block.isDestroy = true;
                                    }
                                    break;
                                }
                            }
                        }
                        if (block.blockType.type == BlockType.TLTriangleBlock ||
                            block.blockType.type == BlockType.TRTriangleBlock ||
                            block.blockType.type == BlockType.BLTriangleBlock ||
                            block.blockType.type == BlockType.BRTriangleBlock)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                pointPos = new Vector2(0, 0);
                                if (block.blockType.type == BlockType.TLTriangleBlock)
                                {
                                    pointPos = new Vector2(block.scaleMultiplier.value * (((i % 3 * (i / 3 * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                }
                                if (block.blockType.type == BlockType.TRTriangleBlock)
                                {
                                    pointPos = new Vector2(block.scaleMultiplier.value * ((2 - (i % 3 * (i / 3 * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                }
                                if (block.blockType.type == BlockType.BLTriangleBlock)
                                {
                                    pointPos = new Vector2(block.scaleMultiplier.value * (((i % 3 * ((2 - (i / 3)) * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                }
                                if (block.blockType.type == BlockType.BRTriangleBlock)
                                {
                                    pointPos = new Vector2(block.scaleMultiplier.value * ((2 - (i % 3 * ((2 - (i / 3)) * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                }
                                Debug.Log(pointPos);
                                DrawLine(new Vector2(pointPos.x + 0.1f + block.position.value.x + 1, pointPos.y + 0.1f + block.position.value.y),
                                    new Vector2(pointPos.x + block.position.value.x + 1, pointPos.y + block.position.value.y), Color.white, 0.4f);
                                if ((entity.collision.self.position.value.x - 0.5f - entity.collision.self.radius.value
                                    < block.position.value.x + pointPos.x && block.position.value.x + pointPos.x
                                    < entity.collision.self.position.value.x + 0.5f + entity.collision.self.radius.value) &&
                                    (entity.collision.self.position.value.y - 0.5f - entity.collision.self.radius.value
                                    < block.position.value.y + pointPos.y && block.position.value.y + pointPos.y
                                    < entity.collision.self.position.value.y + 0.5f + entity.collision.self.radius.value))
                                {
                                    block.health.value -= entity.collision.self.damage.value;
                                    block.text.value.text = block.health.value.ToString();
                                    if (block.health.value <= 0)
                                    {
                                        block.isDestroy = true;
                                    }
                                    break;
                                }
                            }
                        }
                    }

                    if (entity.collision.self.health.value <= 0)
                    {
                        entity.collision.self.isDestroy = true;
                    }

                    //Collider2D[] bombedBlocks = Physics2D.OverlapBoxAll(entity.collision.self.position.value, new Vector2(entity.collision.self.radius.value, entity.collision.self.radius.value), 0f);
                    //foreach (var block in _blockGroup.GetEntities())
                    //{
                    //    if (block.blockType.type == BlockType.SquareBlock)
                    //    {
                    //        foreach (Collider2D br in bombedBlocks)
                    //        {
                    //            if (GameObject.ReferenceEquals(block.prefab.prefab, br.gameObject))
                    //            {
                    //                block.health.value -= entity.collision.self.damage.value;
                    //                block.text.value.text = block.health.value.ToString();
                    //                if (block.health.value <= 0)
                    //                {
                    //                    block.isDestroy = true;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //if (entity.collision.self.health.value <= 0)
                    //{
                    //    entity.collision.self.isDestroy = true;
                    //}
                }
                if (entity.collision.self.blockType.type == BlockType.Laser)
                {
                    entity.collision.self.health.value--;
                    entity.collision.self.text.value.text = entity.collision.self.health.value.ToString();
                    Vector2 pointPos;

                    Vector2 rotatedCorner = new Vector2();
                    Vector2 offset = new Vector2();
                    bool hit = false;
                    LineRenderer line = entity.collision.self.prefab.prefab.GetComponent<LineRenderer>();
                    //for (int i = 0; i < entity.collision.self.laserDirections.angle.Length; i++)
                    //{
                    //    line.positionCount = entity.collision.self.laserDirections.angle.Length * 3;
                    //    line.SetPosition(i * 3 + 0, Rotate(Vector2.left * (entity.collision.self.radius.value + 0.5f), entity.collision.self.laserDirections.angle[i] * Mathf.Deg2Rad));
                    //    line.SetPosition(i * 3 + 1, Rotate(Vector2.right * (entity.collision.self.radius.value + 0.5f), entity.collision.self.laserDirections.angle[i] * Mathf.Deg2Rad));
                    //    line.SetPosition(i * 3 + 2, new Vector2(0, 0));
                    //}
                    foreach(LineRenderer _line in entity.collision.self.line.lines)
                    {
                        _line.enabled = true;
                    }

                    if (entity.collision.self.hasCooldown)
                    {
                        entity.collision.self.ReplaceCooldown(0.1f);
                    }
                    else
                        entity.collision.self.AddCooldown(0.1f);
                    //foreach (float angle in entity.collision.self.laserDirections.angle)
                    //{
                    //    line.SetPosition(0, Rotate(Vector2.left * (entity.collision.self.radius.value + 0.5f), angle * Mathf.Deg2Rad));
                    //    line.SetPosition(1, Rotate(Vector2.right * (entity.collision.self.radius.value + 0.5f), angle * Mathf.Deg2Rad));
                    //    line.SetPosition(2, new Vector2(0, 0));
                    //    //DrawLine(
                    //    //    new Vector2(Rotate(Vector2.left * (entity.collision.self.radius.value + 0.5f), angle * Mathf.Deg2Rad).x + entity.collision.self.position.value.x,
                    //    //                Rotate(Vector2.left * (entity.collision.self.radius.value + 0.5f), angle * Mathf.Deg2Rad).y + entity.collision.self.position.value.y),
                    //    //    new Vector2(Rotate(Vector2.right * (entity.collision.self.radius.value + 0.5f), angle * Mathf.Deg2Rad).x + entity.collision.self.position.value.x,
                    //    //                Rotate(Vector2.right * (entity.collision.self.radius.value + 0.5f), angle * Mathf.Deg2Rad).y + entity.collision.self.position.value.y),
                    //    //                Color.red, 0.2f);
                    //}

                    foreach (var block in _blockGroup.GetEntities())
                    {
                        if (block.blockType.type == BlockType.SquareBlock &&
                            (block.position.value - entity.collision.self.position.value).sqrMagnitude <=
                            (entity.collision.self.radius.value + entity.collision.self.scaleMultiplier.value / 2 + block.scaleMultiplier.value / 2) *
                            (entity.collision.self.radius.value + entity.collision.self.scaleMultiplier.value / 2 + block.scaleMultiplier.value / 2))
                        {
                            foreach (float angle in entity.collision.self.laserDirections.angle)
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    offset = new Vector2(((block.scaleMultiplier.value / 2) * (i % 3)) - (block.scaleMultiplier.value / 2), ((block.scaleMultiplier.value / 2) * (i / 3)) - (block.scaleMultiplier.value / 2));
                                    rotatedCorner = Rotate(block.position.value - entity.collision.self.position.value + offset, -angle * Mathf.Deg2Rad) + entity.collision.self.position.value;
                                    //DrawLine(entity.collision.self.position.value, rotatedCorner, Color.white, 0.4f);
                                    if ((entity.collision.self.position.value.x - 0.5f - entity.collision.self.radius.value
                                        < rotatedCorner.x && rotatedCorner.x
                                        < entity.collision.self.position.value.x + 0.5f + entity.collision.self.radius.value) &&
                                        (entity.collision.self.position.value.y - 0.15f
                                        < rotatedCorner.y && rotatedCorner.y
                                        < entity.collision.self.position.value.y + 0.15f))
                                    {
                                        block.health.value -= entity.collision.self.damage.value;
                                        block.text.value.text = block.health.value.ToString();
                                        if (block.health.value <= 0)
                                        {
                                            block.isDestroy = true;
                                        }
                                        hit = true;
                                        break;
                                    }
                                }
                                if (hit)
                                {
                                    hit = false;
                                    break;
                                }
                            }
                        }
                        if ((block.blockType.type == BlockType.TLTriangleBlock ||
                            block.blockType.type == BlockType.TRTriangleBlock ||
                            block.blockType.type == BlockType.BLTriangleBlock ||
                            block.blockType.type == BlockType.BRTriangleBlock) &&
                            (block.position.value - entity.collision.self.position.value).sqrMagnitude <=
                            (entity.collision.self.radius.value + entity.collision.self.scaleMultiplier.value / 2 + block.scaleMultiplier.value / 2) *
                            (entity.collision.self.radius.value + entity.collision.self.scaleMultiplier.value / 2 + block.scaleMultiplier.value / 2))
                        {
                            foreach (float angle in entity.collision.self.laserDirections.angle)
                            {
                                for (int i = 0; i < 9; i++)
                                {
                                    pointPos = new Vector2(0, 0);
                                    if (block.blockType.type == BlockType.TLTriangleBlock)
                                    {
                                        pointPos = new Vector2(block.scaleMultiplier.value * (((i % 3 * (i / 3 * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                    }
                                    if (block.blockType.type == BlockType.TRTriangleBlock)
                                    {
                                        pointPos = new Vector2(block.scaleMultiplier.value * ((2 - (i % 3 * (i / 3 * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                    }
                                    if (block.blockType.type == BlockType.BLTriangleBlock)
                                    {
                                        pointPos = new Vector2(block.scaleMultiplier.value * (((i % 3 * ((2 - (i / 3)) * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                    }
                                    if (block.blockType.type == BlockType.BRTriangleBlock)
                                    {
                                        pointPos = new Vector2(block.scaleMultiplier.value * ((2 - (i % 3 * ((2 - (i / 3)) * 0.5f)) - 1) / 2f), block.scaleMultiplier.value * (((i / 3) - 1) / 2f));
                                    }
                                    rotatedCorner = Rotate(block.position.value - entity.collision.self.position.value + pointPos, -angle * Mathf.Deg2Rad) + entity.collision.self.position.value;

                                    //DrawLine(new Vector2(pointPos.x + 0.1f + block.position.value.x + 1, pointPos.y + 0.1f + block.position.value.y),
                                    //    new Vector2(pointPos.x + block.position.value.x + 1, pointPos.y + block.position.value.y), Color.white, 0.4f);
                                    if ((entity.collision.self.position.value.x - 0.5f - entity.collision.self.radius.value
                                        < rotatedCorner.x && rotatedCorner.x
                                        < entity.collision.self.position.value.x + 0.5f + entity.collision.self.radius.value) &&
                                        (entity.collision.self.position.value.y - 0.15f
                                        < rotatedCorner.y && rotatedCorner.y
                                        < entity.collision.self.position.value.y + 0.15f))
                                    {
                                        block.health.value -= entity.collision.self.damage.value;
                                        block.text.value.text = block.health.value.ToString();
                                        if (block.health.value <= 0)
                                        {
                                            block.isDestroy = true;
                                        }
                                        hit = true;
                                        break;
                                    }
                                }
                                if (hit)
                                {
                                    hit = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (entity.collision.self.health.value <= 0)
                    {
                        entity.collision.self.isDestroy = true;
                    }
                    //foreach (float angle in entity.collision.self.laserDirections.angle)
                    //{
                    //    Collider2D[] laseredBlocks = Physics2D.OverlapBoxAll(entity.collision.self.position.value, new Vector2(entity.collision.self.radius.value * 2, 0.3f), angle);
                    //    foreach (Collider2D br in laseredBlocks)
                    //    {
                    //        DrawLine(
                    //            new Vector2(rotate(Vector2.left * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).x + entity.collision.self.position.value.x,
                    //                        rotate(Vector2.left * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).y + entity.collision.self.position.value.y),
                    //            new Vector2(rotate(Vector2.right * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).x + entity.collision.self.position.value.x,
                    //                        rotate(Vector2.right * entity.collision.self.radius.value, angle * Mathf.Deg2Rad).y + entity.collision.self.position.value.y),
                    //                        Color.red, 0.2f);
                    //        foreach (var block in _blockGroup.GetEntities())
                    //        {
                    //            if (block.blockType.type == BlockType.SquareBlock)
                    //            {
                    //                if (GameObject.ReferenceEquals(block.prefab.prefab, br.gameObject))
                    //                {
                    //                    block.health.value -= entity.collision.self.damage.value;
                    //                    block.text.value.text = block.health.value.ToString();
                    //                    if (block.health.value <= 0)
                    //                    {
                    //                        block.isDestroy = true;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //if (entity.collision.self.health.value <= 0)
                    //{
                    //    entity.collision.self.isDestroy = true;
                    //}
                }
            }
            if (entity.collision.self.isBoundary)
            {
                if (entity.collision.other.isBall)
                {
                    if (!_pointerGroup.GetSingleEntity().hasNewPointerPosition)
                    {
                        _pointerGroup.GetSingleEntity().AddNewPointerPosition(new Vector2(entity.collision.other.prefab.prefab.transform.position.x, _pointerGroup.GetSingleEntity().position.value.y));
                    }
                    entity.collision.other.isDestroy = true;
                }
            }
            entity.isDestroy = true;
        }
    }
    public static Vector2 Rotate(Vector2 v, float delta)
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
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
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