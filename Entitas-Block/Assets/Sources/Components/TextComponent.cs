using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.UI;

[Game, Unique]
public class TextComponent : IComponent
{
    public Text value;
}
