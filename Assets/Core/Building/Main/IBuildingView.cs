
public interface IBuildingView
{
    IBuilding currentModel { get; }
    void OnClick();

    void SetModel(IBuilding model);

}
