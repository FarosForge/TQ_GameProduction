using System;

public interface IWork
{
    Action OnStopWorking { get; set; }
    public int ResourceCount { get; }
    public IResource[] Resources { get; }
    public float ProductionTime { get; }
    public bool InWorking { get; }

    void StartWork(IWorkData data);
    void StopWork();
    void ResultWork(I_Item item);
}
