//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NewPointerPositionComponent newPointerPosition { get { return (NewPointerPositionComponent)GetComponent(GameComponentsLookup.NewPointerPosition); } }
    public bool hasNewPointerPosition { get { return HasComponent(GameComponentsLookup.NewPointerPosition); } }

    public void AddNewPointerPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.NewPointerPosition;
        var component = (NewPointerPositionComponent)CreateComponent(index, typeof(NewPointerPositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceNewPointerPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.NewPointerPosition;
        var component = (NewPointerPositionComponent)CreateComponent(index, typeof(NewPointerPositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveNewPointerPosition() {
        RemoveComponent(GameComponentsLookup.NewPointerPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherNewPointerPosition;

    public static Entitas.IMatcher<GameEntity> NewPointerPosition {
        get {
            if (_matcherNewPointerPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NewPointerPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNewPointerPosition = matcher;
            }

            return _matcherNewPointerPosition;
        }
    }
}
