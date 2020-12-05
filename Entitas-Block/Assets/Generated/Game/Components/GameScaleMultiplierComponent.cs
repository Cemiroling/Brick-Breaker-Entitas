//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ScaleMultiplierComponent scaleMultiplier { get { return (ScaleMultiplierComponent)GetComponent(GameComponentsLookup.ScaleMultiplier); } }
    public bool hasScaleMultiplier { get { return HasComponent(GameComponentsLookup.ScaleMultiplier); } }

    public void AddScaleMultiplier(float newValue) {
        var index = GameComponentsLookup.ScaleMultiplier;
        var component = (ScaleMultiplierComponent)CreateComponent(index, typeof(ScaleMultiplierComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceScaleMultiplier(float newValue) {
        var index = GameComponentsLookup.ScaleMultiplier;
        var component = (ScaleMultiplierComponent)CreateComponent(index, typeof(ScaleMultiplierComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveScaleMultiplier() {
        RemoveComponent(GameComponentsLookup.ScaleMultiplier);
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

    static Entitas.IMatcher<GameEntity> _matcherScaleMultiplier;

    public static Entitas.IMatcher<GameEntity> ScaleMultiplier {
        get {
            if (_matcherScaleMultiplier == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ScaleMultiplier);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScaleMultiplier = matcher;
            }

            return _matcherScaleMultiplier;
        }
    }
}
