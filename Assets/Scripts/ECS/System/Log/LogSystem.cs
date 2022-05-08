using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class LogSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    readonly Contexts _contexts;
    public LogSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    /// <summary>
    ///执行 
    /// </summary>
    /// <param name="entities"></param>
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity logEntity in entities)
        {
            Debug.Log(logEntity.logMsg.message);
        }
    }

    /// <summary>
    /// 筛选器
    /// </summary>
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLogMsg;
    }

    /// <summary>
    /// 触发器
    /// </summary>
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LogMsg);
    }

    public void Initialize()
    {
        _contexts.game.SetLogMsg("hello world!");
    }
}

