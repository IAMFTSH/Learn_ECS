//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Hp hp { get { return (Hp)GetComponent(GameComponentsLookup.Hp); } }
    public bool hasHp { get { return HasComponent(GameComponentsLookup.Hp); } }

    public void AddHp(int newValue) {
        var index = GameComponentsLookup.Hp;
        var component = (Hp)CreateComponent(index, typeof(Hp));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHp(int newValue) {
        var index = GameComponentsLookup.Hp;
        var component = (Hp)CreateComponent(index, typeof(Hp));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHp() {
        RemoveComponent(GameComponentsLookup.Hp);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHp;

    public static Entitas.IMatcher<GameEntity> Hp {
        get {
            if (_matcherHp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Hp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHp = matcher;
            }

            return _matcherHp;
        }
    }
}
