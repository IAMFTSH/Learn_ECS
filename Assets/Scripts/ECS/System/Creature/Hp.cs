using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public class Hp : IComponent
{
    public int value;
}   