namespace APDB3;

public class Ship
{
    private List<Container> containers = new();
    public float maxSpeed { get; }
    public int maxContainerCount { get; }
    public float maxWeight { get; }
    public string name { get; }

    public Ship(string name, float maxSpeed, int maxContainerCount, float maxWeight)
    {
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.maxContainerCount = maxContainerCount;
        this.maxWeight = maxWeight;
    }
    public void LoadContainer(Container container)
    {
        if (containers.Count >= maxContainerCount)
            throw new InvalidOperationException("MAX CAPACITY REACHED");
        if (containers.Sum(c => c.GetTotalWeight()) + container.GetTotalWeight() > maxWeight)
            throw new InvalidOperationException("MAX WEIGHT EXCEEDED");

        containers.Add(container);
    }
    public void UnloadContainer(string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container == null) throw new ArgumentException("container not found");
        containers.Remove(container);
    }
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        UnloadContainer(serialNumber);
        LoadContainer(newContainer);
    }
    public void TransferContainerTo(Ship otherShip, string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.serialNumber == serialNumber);
        if (container == null) throw new ArgumentException("Container not found.");
        UnloadContainer(serialNumber);
        otherShip.LoadContainer(container);
    }
    public void PrintContainers()
    {
        foreach (var container in containers)
        {
            Console.WriteLine(container.serialNumber);
        }
    }
}
