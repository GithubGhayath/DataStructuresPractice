using Shared.Print;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        // Problem 05
        TrackPassword();
        // Problem 04
        // ScheduleTask();

        // Problem 03
        // Theater();

        // Problem 02
        // SurveyResult();

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

    // Use BitArray to track which seats (1,000 seats) in a theater are booked.
    public static void Theater()
    {
        BitArray Seats = new BitArray(1000);
        Seats.SetAll(true);

        Seats.Print("Theater seats status now: ");
    }

    // Represent a weekly schedule with BitArray (7 days). Check which days are free.
    public static void ScheduleTask()
    {
        BitArray Schedule = new BitArray(7, true);
        Schedule[5] = false;
        Schedule[1] = false;
        Schedule[3] = false;

        for (int day = 0; day < Schedule.Length; day++)
        {
            if (!Schedule[day])
                Console.WriteLine($"Day [{day + 1}] is free!");
        }
    }

    // Use a BitArray to track whether a password has an uppercase letter, a lowercase letter, a digit, and a special character.
    private static BitArray _IsPasswordValid(string password)
    {
        BitArray Cases = new BitArray(4); // [0]: uppercase letter, [1]: lowercase letter,[2]: digit, [3]: special character

        foreach (char item in password)
        {

            if (char.IsDigit(item))
            {
                Cases[2] = true;
            }
            else if (char.IsPunctuation(item))
            {
                Cases[3] = true;
            }
            else if (char.IsUpper(item))
            {
                Cases[0] = true;
            }
            else
            {
                Cases[1] = true;
            }
        }

        return Cases;
    }

    private static string CheckWhatIsMissingAtPassword(string password)
    {
        string _Result = string.Empty;
        BitArray Result = _IsPasswordValid(password);
        if (Result.HasAllSet())
            _Result = "Password is valid";
        else
        {

            if (!Result[0])
                _Result = "Missing uppercase letter";
            else if (!Result[1])
                _Result += "\nMissing lowercase letter";
            else if (!Result[2])
                _Result += "\nMissing digit";
            else if (!Result[3])
                _Result += "\nMissing special character";


        }
        return _Result;

    }

    private static void _PrintValidationResult(string password)
    {
        Console.WriteLine($"\nThe password [{password}] is: \n{CheckWhatIsMissingAtPassword(password)}");
    }
    public static void TrackPassword()
    {
        string Password1 = "Abc123!";
        string Password2 = "abc123!";
        string Password3 = "ABC123!";
        string Password4 = "Abcdef!";
        string Password5 = "Abc1234";

        _PrintValidationResult(Password1);
        _PrintValidationResult(Password2);
        _PrintValidationResult(Password3);
        _PrintValidationResult(Password4);
        _PrintValidationResult(Password5);
    }
}