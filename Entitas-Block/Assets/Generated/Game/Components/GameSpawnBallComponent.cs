//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SpawnBallComponent spawnBallComponent = new SpawnBallComponent();

    public bool isSpawnBall {
        get { return HasComponent(GameComponentsLookup.SpawnBall); }
        set {
            if (value != isSpawnBall) {
                var index = GameComponentsLookup.SpawnBall;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : spawnBallComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawnBall;

    public static Entitas.IMatcher<GameEntity> SpawnBall {
        get {
            if (_matcherSpawnBall == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnBall);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnBall = matcher;
            }

            return _matcherSpawnBall;
        }
    }
}
