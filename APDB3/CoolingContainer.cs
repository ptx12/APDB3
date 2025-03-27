namespace APDB3;

public class CoolingContainer : Container
{
    private string productType;
    private float temperature;
    private static readonly Dictionary<string, float> RequiredTemperatures = new()
    {
        { "Meat", -18.0f },
        { "Fish", -20.0f },
        { "Dairy", 2.0f },
        { "Vegetables", 4.0f }
    };

    public CoolingContainer(float load, float height, float containerWeight, float depth, float maxLoad, char containerType, string productType, float temperature) : base(load, height, containerWeight, depth, maxLoad, containerType)
    {
        float requiredTemp = RequiredTemperatures.FirstOrDefault(kv => kv.Key == productType).Value;

        if (!RequiredTemperatures.ContainsKey(productType))
            throw new ArgumentException("uknown type");

        if (temperature < requiredTemp)
            throw new ArgumentException($"temp too low; {productType} requires at least {requiredTemp}C");

        this.productType = productType;
        this.temperature = temperature;
        
    }
}
