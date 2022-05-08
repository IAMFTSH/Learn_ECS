
using Entitas;
using Entitas.Unity;
using TMPro;
using UnityEditor.UnityLinker;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : View,IHpListener
{
    public static CharacterView Inst;
    public TextMeshProUGUI Text;
    public void OnHp(GameEntity entity, int value)
    {
        Text.text = value.ToString();
    }

    public override void Link(IEntity entity)
    {
        if (Inst == null)
        {
            Inst = this;
        }
        var  entityLink = gameObject.GetEntityLink();
        if (entityLink)
        {
            var oldEntity =  (GameEntity)entityLink.entity;
            oldEntity.RemoveHpListener(this);
            gameObject.Unlink();
        }
        base.Link(entity);
        var e = (GameEntity) entity;
        e.AddHpListener(this);
    }
    public static void Show(GameEntity entity)
    {
        var viewEntity = Contexts.sharedInstance.game.CreateEntity();
        viewEntity.AddAsset("CharacterUI");
    }
}
