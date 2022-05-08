using System;
using Entitas;
using UnityEngine;
using Random = System.Random;

public sealed class MouseInputSystem : IExecuteSystem,IInitializeSystem
{
    readonly Contexts _contexts;

    public MouseInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        emitInput();
    }
    

    void emitInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // _contexts.input.ReplaceMousePos(new Vector2Int(
            //     (int)Math.Round(mouseWorldPos.x),
            //     (int)Math.Round(mouseWorldPos.y)
            // ));
            CharacterView.Inst?.Link(CharacterSystem.Create(_contexts.game,new Random().Next()));
        }
    }

    public void Initialize()
    {
        _contexts.input.SetMousePos(new Vector2Int(1,2));
    }
}
