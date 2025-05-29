namespace Core.ValueObjects;

public record Phone(int Prefix, int Number)
{
    public string Present()
    {
        var stringNumber = Number.ToString();
        var presentNumber = "";
        for (var i = 0; i < stringNumber.Length; ++i)
        {
            presentNumber += stringNumber[i];
            if (i % 3 == 0)
            {
                presentNumber += ' ';
            }
        }

        return "+" + Prefix + " " + presentNumber;
    }
}