using Entitas;
using UnityEngine;


public class WorldController : MonoBehaviour
{
    private Systems _systems;
    private Feature _feature;
    void Start()
    {
        var context = Contexts.sharedInstance;
        _feature = new Feature("Systems");
        _systems = _feature.Add(new WorldFeature(context));
        _systems = _feature.Add(new CharacterFeature(context));
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
