
    public class CharacterFeature : Feature
    {
        public CharacterFeature(Contexts contexts) : base("CharacterFeature")
        {
            Add(new CharacterSystem(contexts));
            //Add(new AddViewSystem(contexts));
            // Events (Generated)
            Add(new GameEventSystems(contexts));

        }
    }
