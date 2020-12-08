using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBlockViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private RectTransform _uiRoot;
    private Text _textPref;
    private LineRenderer _linePref;
    public AddBlockViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _uiRoot = _contexts.game.uIRoot.value;
        _textPref = _contexts.game.text.value;
        _linePref = _contexts.game.globals.value.linePrefab.GetComponent<LineRenderer>();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Text text = GameObject.Instantiate(_textPref, _uiRoot);
            text.text = entity.health.value.ToString();
            RectTransform textTransform = text.GetComponent<RectTransform>();
            if (entity.blockType.type == BlockType.SquareBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.blockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100, entity.position.value.y * 100);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

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

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100 - entity.scaleMultiplier.value * 15, entity.position.value.y * 100 + entity.scaleMultiplier.value * 15);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                    gameobject.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
            if (entity.blockType.type == BlockType.TRTriangleBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.triangleBlockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100 + entity.scaleMultiplier.value * 15, entity.position.value.y * 100 + entity.scaleMultiplier.value * 15);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

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

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100 + entity.scaleMultiplier.value * 15, entity.position.value.y * 100 - entity.scaleMultiplier.value * 15);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

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

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100 - entity.scaleMultiplier.value * 15, entity.position.value.y * 100 - entity.scaleMultiplier.value * 15);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

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

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100, entity.position.value.y * 100);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

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
                List<LineRenderer> lines = new List<LineRenderer>();

                textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100, entity.position.value.y * 100);
                textTransform.localScale *= entity.scaleMultiplier.value;
                entity.AddText(text);

                foreach (float angle in entity.laserDirections.angle)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        LineRenderer line = Object.Instantiate(_linePref);
                        line.positionCount = 2;
                        line.SetPosition(0, entity.position.value);
                        line.SetPosition(1, Rotate(Vector2.left * (entity.radius.value + 0.5f), (angle + i * 180) * Mathf.Deg2Rad) + entity.position.value);
                        line.enabled = false;
                        lines.Add(line);
                    }
                }
                entity.AddLine(lines);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
                    gameobject.transform.localScale *= entity.scaleMultiplier.value;
                }
            }


        }
    }

    public Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
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
