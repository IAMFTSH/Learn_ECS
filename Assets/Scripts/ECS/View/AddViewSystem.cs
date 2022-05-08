using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _parent;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _parent = GameObject.Find("Canvas").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Asset);

    protected override bool Filter(GameEntity entity) => entity.hasAsset && !entity.hasView;

    protected override void Execute(List<GameEntity> entities)
    {

    }

    IView instantiateView(GameEntity entity)
    {
        var prefab = Resources.Load<GameObject>(entity.asset.value);
        var view = Object.Instantiate(prefab, _parent).GetComponent<IView>();
        view.Link(entity);
        return view;
    }
}
//改装，通过Show方法创建View，Show参数中加入相应的