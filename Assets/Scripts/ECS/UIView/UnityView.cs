using System;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public abstract class UnityView : MonoBehaviour
{
    protected Contexts Contexts;
    protected GameEntity LinkedEntity;
    public static Dictionary<Type, UnityView> _pool = new Dictionary<Type, UnityView>();
    public static void Show<T>(Action<T> action)where T:UnityView
    {
        var info = UILoadInfo.GetUIInfo<T>();
        if (info.IsSingle && _pool.TryGetValue(typeof(T),out var playerView))
        {
            playerView.gameObject.SetActive(true);
            action((T)playerView);
        }
        else
        {
            var playerViewObj = Resources.Load<GameObject>(info.Path);;
            var e = Contexts.sharedInstance.game.CreateEntity();
            playerViewObj.Link(e); // passing the context is not needed anymore
            playerView = playerViewObj.GetComponent<T>();
            e.AddUnityView(playerView);
            action((T)playerView);
        }
    }
    public virtual void Link(Contexts contexts, GameEntity e)
    {
        Contexts = contexts;
        LinkedEntity = e;
        gameObject.Link(e);
    }
    
    public virtual void DestroyView()
    {
        Destroy(gameObject);
    }
    
}