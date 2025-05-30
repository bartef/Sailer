namespace Core.ValueObjects;

public record Phone(int Prefix, int Number)
{
    public string Present()
    {
        var stringNumber = Number.ToString();
        var presentNumber = "";
        for (var i = 0; i < stringNumber.Length; ++i)
        {
            if (i != 0 && i % 3 == 0)
            {
                presentNumber += ' ';
            }
            presentNumber += stringNumber[i];
        }

        return $"+{Prefix} {presentNumber}";
    }
}