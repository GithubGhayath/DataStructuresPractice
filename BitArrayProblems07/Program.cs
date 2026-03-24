using Shared.Print;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 02
        SurveyResult();

        // Problem 01
        // LightAtSmartHome();
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

    // Store the responses of 5 questions (Yes/No) for a survey of 10 users.
    public static void SurveyResult()
    {
        bool[] arr1 = { false, true, false, false, true };
        bool[] arr2 = { false, true, false, true, true };
        bool[] arr3 = { true, true, false, false, true };
        bool[] arr4 = { false, true, true, false, true };
        bool[] arr5 = { true, true, false, false, false };

        BitArray SurveyFirstUser = new BitArray(arr1);
        BitArray SurveySecondUser = new BitArray(arr2);
        BitArray SurveyThirdUser = new BitArray(arr3);
        BitArray SurveyFourthUser = new BitArray(arr4);
        BitArray SurveyFifthUser = new BitArray(arr5);


        SurveyFirstUser.Print("Survey result of first user");
        SurveySecondUser.Print("Survey result of second user");
        SurveyThirdUser.Print("Survey result of third user");
        SurveyFourthUser.Print("Survey result of fourth user");
        SurveyFifthUser.Print("Survey result of fifth user");
    }
}