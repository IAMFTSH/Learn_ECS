using Entitas;
using UnityEngine;


/// <summary>
/// 初始化系统
/// </summary>
public class InitSystem : IInitializeSystem
{
    private readonly Contexts _contexts;

    public InitSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var player1 = CharacterSystem.Create(_contexts.game,100);
        var player2 = CharacterSystem.Create(_contexts.game,100);
    }
}

