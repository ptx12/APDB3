namespace APDB3;

public class GasContainer : Container, IHazardNotifier
{
    private float pressure;

    public GasContainer(float load, float height, float containerWeight, float depth, float maxLoad, char containerType, float pressure) : base(load, height, containerWeight, depth, maxLoad, containerType)
    {
        this.pressure = pressure;
    }
    public void Notify(string message) => Console.WriteLine($"HAZARD ALERT FOR A GAS CONTAINER: ({serialNumber}): {message}");
    public override void EmptyLoad() => this.load *= 0.05f;
}