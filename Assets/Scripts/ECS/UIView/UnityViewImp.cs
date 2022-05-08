
public class UnityViewImp:UnityView
{
    
    public override void DestroyView()
    {
    }
    
    private void DelayedDestroy()
    {
        base.DestroyView();
    }
}
