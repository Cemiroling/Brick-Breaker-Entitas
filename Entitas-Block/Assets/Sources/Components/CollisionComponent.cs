using Entitas;

[Game]
public sealed class CollisionComponent : IComponent
{
    public GameEntity self;
    public GameEntity other;
}
