using Entitas;
using UnityEngine;

public class CooldownSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _cooldownGroup;
    private Contexts _contexts;

    public CooldownSystem(Contexts contexts)
    {
        _contexts = contexts;
        _cooldownGroup = _contexts.game.GetGroup(GameMatcher.Cooldown);
    }
    public void Execute()
    {
        float deltaTime = Time.deltaTime;
        foreach (var e in _cooldownGroup.GetEntities())
        {
            e.ReplaceCooldown(e.cooldown.value - deltaTime);
            if (e.cooldown.value <= 0)
            {
                e.RemoveCooldown();
                foreach (LineRenderer _line in e.line.lines)
                {
                    _line.enabled = false;
                }
            }
        }
    }
}