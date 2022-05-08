using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input,Unique]
public class MousePosComponent : IComponent
{
    public Vector2Int value;
}
