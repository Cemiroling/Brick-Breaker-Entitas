//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly BoundaryComponent boundaryComponent = new BoundaryComponent();

    public bool isBoundary {
        get { return HasComponent(GameComponentsLookup.Boundary); }
        set {
            if (value != isBoundary) {
                var index = GameComponentsLookup.Boundary;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : boundaryComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherBoundary;

    public static Entitas.IMatcher<GameEntity> Boundary {
        get {
            if (_matcherBoundary == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Boundary);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBoundary = matcher;
            }

            return _matcherBoundary;
        }
    }
}
