//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LaserDirectionsComponent laserDirections { get { return (LaserDirectionsComponent)GetComponent(GameComponentsLookup.LaserDirections); } }
    public bool hasLaserDirections { get { return HasComponent(GameComponentsLookup.LaserDirections); } }

    public void AddLaserDirections(float[] newAngle) {
        var index = GameComponentsLookup.LaserDirections;
        var component = (LaserDirectionsComponent)CreateComponent(index, typeof(LaserDirectionsComponent));
        component.angle = newAngle;
        AddComponent(index, component);
    }

    public void ReplaceLaserDirections(float[] newAngle) {
        var index = GameComponentsLookup.LaserDirections;
        var component = (LaserDirectionsComponent)CreateComponent(index, typeof(LaserDirectionsComponent));
        component.angle = newAngle;
        ReplaceComponent(index, component);
    }

    public void RemoveLaserDirections() {
        RemoveComponent(GameComponentsLookup.LaserDirections);
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

    static Entitas.IMatcher<GameEntity> _matcherLaserDirections;

    public static Entitas.IMatcher<GameEntity> LaserDirections {
        get {
            if (_matcherLaserDirections == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LaserDirections);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLaserDirections = matcher;
            }

            return _matcherLaserDirections;
        }
    }
}