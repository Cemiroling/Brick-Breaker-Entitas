//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ClickInputComponent clickInputComponent = new ClickInputComponent();

    public bool isClickInput {
        get { return HasComponent(GameComponentsLookup.ClickInput); }
        set {
            if (value != isClickInput) {
                var index = GameComponentsLookup.ClickInput;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : clickInputComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherClickInput;

    public static Entitas.IMatcher<GameEntity> ClickInput {
        get {
            if (_matcherClickInput == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ClickInput);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherClickInput = matcher;
            }

            return _matcherClickInput;
        }
    }
}
