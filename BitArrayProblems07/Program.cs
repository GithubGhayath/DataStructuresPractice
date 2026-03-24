using Shared.Print;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 01:
        LightAtSmartHome();
    }

    // Represent the state of lights in a smart home system with 8 lights. Update the status of specific lights and turn all lights off at once.
    public static void LightAtSmartHome()
    {
        bool[] arr = { false, true, false, false, true, true, true, false };
        BitArray Lights = new BitArray(arr);


        Lights.Print("State of lights new: ");
        Console.WriteLine($"Turning lights of:");
        Lights.SetAll(false);
        Lights.Print("State of lights new: ");
    }
}