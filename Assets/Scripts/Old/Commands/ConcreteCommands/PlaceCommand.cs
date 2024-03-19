public class PlaceCommand : ICommand
{
    public PlaceCommand()
    {
    }

    public void Execute()
    {
        GameManager.Instance.PlaceTrinket();
    }
}
