public class WorkMinigData : IWorkData
{
    public IResource resource;

    public WorkMinigData(IResource resource)
    {
        this.resource = resource;
    }
}
