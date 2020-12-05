using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private IGroup<GameEntity> _blockGroup;
    public MovingBlockSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _blockGroup = _contexts.game.GetGroup(GameMatcher.Block);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.isDestroy = true;

            Vector3 minusPosition3 = Vector3.down;
            Vector2 minusPosition2 = Vector2.down;

            foreach (var block in _blockGroup)
            {
                block.position.value.y--;
                if (block.position.value.y < Screen.height / 200f)
                {
                    if (block.isViewable)
                    {
                        block.prefab.prefab.transform.position += minusPosition3;
                        RectTransform textTransform = block.text.value.GetComponent<RectTransform>();
                        textTransform.anchoredPosition += minusPosition2 * 100;
                    }
                    else
                    {
                        Debug.Log("Works");
                        block.isViewable = true;
                    }
                }
            }
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMoveBlock;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveBlock);
    }
}