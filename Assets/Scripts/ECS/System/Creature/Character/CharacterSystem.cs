using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CharacterSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public CharacterSystem(Contexts context) : base(context.game)
    {
        _contexts = context;
    }
    

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Hp);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHp;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            _contexts.game.ReplaceLogMsg(entity.hp.value.ToString());
        }
    }

    public static GameEntity Create(GameContext context,int hp)
    {
        var entity = context.CreateEntity();
        entity.AddHp(hp);
        entity.isMovable = true;
        return entity;
    }
}