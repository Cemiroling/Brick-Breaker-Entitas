using Entitas;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class LineComponent : IComponent
{
    public List<LineRenderer> lines;
}