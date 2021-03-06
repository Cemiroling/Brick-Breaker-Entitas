//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LineComponent line { get { return (LineComponent)GetComponent(GameComponentsLookup.Line); } }
    public bool hasLine { get { return HasComponent(GameComponentsLookup.Line); } }

    public void AddLine(System.Collections.Generic.List<UnityEngine.LineRenderer> newLines) {
        var index = GameComponentsLookup.Line;
        var component = (LineComponent)CreateComponent(index, typeof(LineComponent));
        component.lines = newLines;
        AddComponent(index, component);
    }

    public void ReplaceLine(System.Collections.Generic.List<UnityEngine.LineRenderer> newLines) {
        var index = GameComponentsLookup.Line;
        var component = (LineComponent)CreateComponent(index, typeof(LineComponent));
        component.lines = newLines;
        ReplaceComponent(index, component);
    }

    public void RemoveLine() {
        RemoveComponent(GameComponentsLookup.Line);
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

    static Entitas.IMatcher<GameEntity> _matcherLine;

    public static Entitas.IMatcher<GameEntity> Line {
        get {
            if (_matcherLine == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Line);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLine = matcher;
            }

            return _matcherLine;
        }
    }
}
