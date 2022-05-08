using Entitas;
using Entitas.CodeGeneration.Attributes;


/// <summary>
/// 打印消息的组件
/// </summary>
[Unique] //Entitas中Atrribute，方便标记组件所属entities，提高内存效率
public class LogMsg : IComponent
{
    /// <summary>
    /// 打印信息
    /// </summary>
    public string message;
}

