using System;


class DeclareStrings
{
    static void Main()
    {
        string firstString = "Zariba";
        string secondString = "Academy";
        object toSumTheStrings = firstString + " " + secondString;
        string thirdString = toSumTheStrings.ToString();
    }
}