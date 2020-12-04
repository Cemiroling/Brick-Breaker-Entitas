//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SetNewPointerPositionComponent setNewPointerPositionComponent = new SetNewPointerPositionComponent();

    public bool isSetNewPointerPosition {
        get { return HasComponent(GameComponentsLookup.SetNewPointerPosition); }
        set {
            if (value != isSetNewPointerPosition) {
                var index = GameComponentsLookup.SetNewPointerPosition;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : setNewPointerPositionComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherSetNewPointerPosition;

    public static Entitas.IMatcher<GameEntity> SetNewPointerPosition {
        get {
            if (_matcherSetNewPointerPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SetNewPointerPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSetNewPointerPosition = matcher;
            }

            return _matcherSetNewPointerPosition;
        }
    }
}
