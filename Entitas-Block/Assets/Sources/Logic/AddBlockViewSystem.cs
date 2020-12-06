using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;
using UnityEngine.UI;

public class AddBlockViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private RectTransform uiRoot;
    private Text textPref;
    public AddBlockViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        uiRoot = _contexts.game.uIRoot.value;
        textPref = _contexts.game.text.value;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Text text = GameObject.Instantiate(textPref, uiRoot);
            text.text = entity.health.value.ToString();
            RectTransform textTransform = text.GetComponent<RectTransform>();
            textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100, entity.position.value.y * 100);
            textTransform.localScale *= entity.scaleMultiplier.value;
            entity.AddText(text);
            if (entity.blockType.type == BlockType.SquareBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.blockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                }
            }
            if (entity.blockType.type == BlockType.TLTriangleBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.triangleBlockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                    gameobject.transform.rotation = Quaternion.Euler(0 , 0, 90);
                }
            }
            if (entity.blockType.type == BlockType.TRTriangleBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.triangleBlockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                    gameobject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            if (entity.blockType.type == BlockType.BRTriangleBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.triangleBlockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                    gameobject.transform.rotation = Quaternion.Euler(0, 0, 270);
                }
            }
            if (entity.blockType.type == BlockType.BLTriangleBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.triangleBlockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                    gameobject.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
            if (entity.blockType.type == BlockType.Bomb)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.bombPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                }
            }
            if (entity.blockType.type == BlockType.Laser)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.laserPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isBlock && entity.hasPosition && entity.hasBlockType && entity.isViewable;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Block, GameMatcher.Position, GameMatcher.BlockType, GameMatcher.Viewable));
    }
}
