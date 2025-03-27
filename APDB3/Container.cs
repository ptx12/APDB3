namespace APDB3;

public class OverfillException : Exception
{
    public OverfillException(string message): base(message) { }
}

public class Container
{
    private static int containerID = 0;
    private static List<char> containerList = ['L', 'G', 'C'];

    protected float load;
    protected float height;
    protected float containerWeight;
    protected float depth;
    protected float maxLoad;
    
    private char containerType;
    public string serialNumber;
    
    public Container(float load, float height, float containerWeight, float depth, float maxLoad, char containerType)
    {
        this.load = load;
        this.height = height;
        this.containerWeight = containerWeight;
        this.depth = depth;
        this.maxLoad = maxLoad;
        this.containerType = containerType;
        serialNumber = GenerateSerialNumber(containerType);
    }

    private string GenerateSerialNumber(char t)
    {
        if (!containerList.Contains(t)) throw new ArgumentException("Invalid container type");
        return $"KON-{containerType}-{containerID++}";
    }
    public virtual void EmptyLoad() => this.load = 0;
    public virtual void AddLoad(float load)
    {
        if (this.load + load > maxLoad) throw new OverfillException("Overfill");
        this.load += load;
    }
    public float GetTotalWeight() => containerWeight + load; // MUSI BYĆ DLA SHip

}