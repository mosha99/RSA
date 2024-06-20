using System.Numerics;
using System.Text;

namespace RSA.Service;

public class RsaKeyGenerator(PrimeKeys primeKeys)
{
    public GeneratedKeys? GenerateKeys()
    {
        var sharedKey = primeKeys.NumericSecondKey * primeKeys.NumericFirstKey;

        var maxNumber = (primeKeys.NumericFirstKey - 1) * (primeKeys.NumericSecondKey - 1);

        BigInteger firstCounter = 0;
        while (true)
        {
            var checkCountOut = maxNumber / 4;

            if (firstCounter > sharedKey * (BigInteger)1.5) checkCountOut = sharedKey * maxNumber * maxNumber;

            firstCounter++;

            var publicKey = GenerateRandomBigInteger(maxNumber);

            if (publicKey == 0) continue;

            if (IsPrimeWith(publicKey, maxNumber) && IsPrimeWith(publicKey, sharedKey))
            {
                BigInteger secondCounter = 0;
                while (secondCounter < checkCountOut)
                {
                    secondCounter++;

                    var d = GenerateRandomBigInteger(maxNumber);

                    var privateKey = (d * maxNumber + 1) / publicKey;

                    if (privateKey * publicKey % maxNumber == 1)
                        return new GeneratedKeys(publicKey.ToString(), privateKey.ToString(), sharedKey.ToString());
                }
            }
        }
    }

    private bool IsPrimeWith(BigInteger number, BigInteger target)
    {
        return target % number != 0;
    }

    private BigInteger GenerateRandomBigInteger(BigInteger max)
    {
        var strMax = max.ToString();

        var result = new StringBuilder();

        for (var i = 1; i < strMax.Length; i++)
        {
            var rn = new Random();
            result.Append(rn.Next(0, 10));
        }

        while (true)
        {
            var rn = new Random();
            var firstNumber = rn.Next(0, int.Parse(strMax[0].ToString()) + 1);
            var numericResult = BigInteger.Parse(string.Join("", firstNumber.ToString(), result.ToString()));
            if (numericResult <= max) return numericResult;
        }
    }
}