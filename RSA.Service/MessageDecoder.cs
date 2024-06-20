using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace RSA.Service;

public class MessageDecoder
{
    public static BigInteger Encode(BigInteger message, BigInteger publicKey, BigInteger shareKey)
    {
        BigInteger result = 1;
        for (var i = 0; i < publicKey; i++) result *= message;
        return result % shareKey;
    }

    public static BigInteger Decode(BigInteger message, BigInteger privateKey, BigInteger shareKey)
    {
        BigInteger result = 1;
        for (var i = 0; i < privateKey; i++) result *= message;
        return result % shareKey;
    }

    public static BigInteger Encode(string message, string publicKey, string shareKey)
    {
        return Encode(message.ToBigInteger(), publicKey.ToBigInteger(), shareKey.ToBigInteger());
    }

    public static BigInteger Decode(string message, string privateKey, string shareKey)
    {
        return Decode(message.ToBigInteger(), privateKey.ToBigInteger(), shareKey.ToBigInteger());
    }
}