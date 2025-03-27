namespace APDB3;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool containsHazardousMaterials;

    public LiquidContainer(float load, float height, float containerWeight, float depth, float maxLoad, char containerType, bool containsHazardousMaterials = true) 
        : base(load, height, containerWeight, depth, maxLoad, containerType)
    {
        this.containsHazardousMaterials = containsHazardousMaterials;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"HAZARD ALERT: ({serialNumber}): {message}");
    }

    public override void AddLoad(float load)
    {
        if (this.load + load > (containsHazardousMaterials ? maxLoad * 0.5f : maxLoad * 0.9f))
        {
            Notify($"ATTEMPTED TO OVERLOAD CONTAINER");
            throw new OverfillException("cannot fill over the safety limit");
        }

        this.load += load;
    }
}