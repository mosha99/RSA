using System.Numerics;
using System.Text;

namespace RSA.Service;

public static class Helper
{
    public static BigInteger ToBigInteger(this string input)
    {

        if (BigInteger.TryParse(input, out BigInteger result)) return result;

        StringBuilder builder = new();

        foreach (var b in Encoding.ASCII.GetBytes(input))
        {
            builder.Append(b);
        }

        return BigInteger.Parse(builder.ToString());

    }
}