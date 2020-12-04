//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BlockTypeComponent blockType { get { return (BlockTypeComponent)GetComponent(GameComponentsLookup.BlockType); } }
    public bool hasBlockType { get { return HasComponent(GameComponentsLookup.BlockType); } }

    public void AddBlockType(BlockType newType) {
        var index = GameComponentsLookup.BlockType;
        var component = (BlockTypeComponent)CreateComponent(index, typeof(BlockTypeComponent));
        component.type = newType;
        AddComponent(index, component);
    }

    public void ReplaceBlockType(BlockType newType) {
        var index = GameComponentsLookup.BlockType;
        var component = (BlockTypeComponent)CreateComponent(index, typeof(BlockTypeComponent));
        component.type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveBlockType() {
        RemoveComponent(GameComponentsLookup.BlockType);
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

    static Entitas.IMatcher<GameEntity> _matcherBlockType;

    public static Entitas.IMatcher<GameEntity> BlockType {
        get {
            if (_matcherBlockType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BlockType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBlockType = matcher;
            }

            return _matcherBlockType;
        }
    }
}
