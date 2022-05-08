
    /// <summary>
    /// 将创建的系统添加到框架内
    /// </summary>
    public class WorldFeature : Feature
    {
        public WorldFeature(Contexts contexts) : base("WorldFeature")
        {
            Add(new LogSystem(contexts));
            Add(new MouseInputSystem(contexts));
            Add(new InitSystem(contexts));
        }
    }
