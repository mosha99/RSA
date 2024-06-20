using System.Numerics;

namespace RSA.Service;

public class PrimeKeys(string firstKey, string secondKey)
{
    public BigInteger NumericFirstKey => firstKey!.ToBigInteger();
    public BigInteger NumericSecondKey => secondKey!.ToBigInteger();

    public bool FirstKeyValidate() => IsPrime(NumericFirstKey);
    public bool SecondKeyValidate() => IsPrime(NumericSecondKey);

    bool IsPrime(BigInteger number)
    {
        for (BigInteger i = 2; i < number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}