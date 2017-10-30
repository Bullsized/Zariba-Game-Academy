using System.Numerics;

class Program
{
    static void Main()
    {
        // integer types
        sbyte signedEightBit = 108;
        byte unsignedEightBit = 207;
        short signedSixteenBit = -11115;
        ushort unsignedSixteenBit = 11511;
        int signedThirtyTwoBit = -111111111;
        uint unsignedThirtyTwoBit = 111111111;
        long signedSixtyFourBit = 133713371337;
        ulong unsignedSixtyFourBit = 1337133713371337;
        BigInteger hugeNumber = 13371337133713371337;

        // floating point
        float firstFloat = 5.22f;
        double secondFloat = 22.5d;
        decimal thirdFloat = 2.52m;

        // boolean
        bool lampIsOn = true;
        lampIsOn = false;

        // character
        char alpha = 'a';

        // string
        string food = "Mekici";

        // object
        object drinks = "Boza";
        drinks = 42;

        // dynamic
        dynamic table = "Sofra";
        table = 'z';
        table = 'a';
        table = "dvama!";
    }
}
