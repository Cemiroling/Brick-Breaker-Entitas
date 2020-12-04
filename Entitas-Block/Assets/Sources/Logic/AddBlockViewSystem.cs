﻿using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity;
using UnityEngine.UI;

public class AddBlockViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public AddBlockViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        RectTransform uiRoot = _contexts.game.uIRoot.value;
        Text textPref = _contexts.game.text.value;
        foreach (var entity in entities)
        {
            Text text = GameObject.Instantiate(textPref, uiRoot);
            text.text = entity.health.value.ToString();
            RectTransform textTransform = text.GetComponent<RectTransform>();
            textTransform.anchoredPosition = new Vector2(entity.position.value.x * 100, entity.position.value.y * 100);        
            entity.AddText(text);
            if (entity.blockType.type == BlockType.SquareBlock)
            {
                var gameobject = Object.Instantiate(_contexts.game.globals.value.blockPrefab);
                entity.AddPrefab(gameobject);
                gameobject.Link(entity);
                if (entity.hasPosition)
                {
                    gameobject.transform.position = entity.position.value;
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
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isBlock && entity.hasPosition && entity.hasBlockType;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Block, GameMatcher.Position, GameMatcher.BlockType));
    }
}