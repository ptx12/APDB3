
using APDB3;

public static class Program
{
    public static void Main()
    {
        Ship ship1 = new Ship("a", 25.0f, 100, 50000.0f);
        Ship ship2 = new Ship("a2", 30.0f, 120, 60000.0f);

        CoolingContainer containerMeat = new CoolingContainer(1000, 2.5f, 500, 2.0f, 2000, 'C', "Meat", -18);
        GasContainer containerGas = new GasContainer(500, 3.0f, 400, 2.5f, 1500, 'G', 200);
        LiquidContainer containerLiquid = new LiquidContainer(800, 2.8f, 450, 2.2f, 1800, 'L', true);

        //Console.WriteLine(containerGas);
        ship1.LoadContainer(containerMeat);
        ship1.LoadContainer(containerGas);
        ship1.LoadContainer(containerLiquid);
        ship1.PrintContainers();

        //ship1.PrintContainers()
        ship1.TransferContainerTo(ship2, containerGas.serialNumber);
        
        
        Console.WriteLine("SHIP 1 PO TRANSFER");
        ship1.PrintContainers();
        //ship2.PrintContainers();
        
        ship1.UnloadContainer(containerMeat.serialNumber);
        ship1.PrintContainers();

        Console.WriteLine("overfill test");
        try
        {
            containerLiquid.AddLoad(2000);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        containerLiquid.Notify("LEAK DETECTED");
    }
}