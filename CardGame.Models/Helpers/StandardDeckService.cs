namespace CardGame.Models.Helpers;

//TODO: Convert to DI compatable service function. 
public static class StandardDeckService
{
    public static string ConvertIntToStandardRankString(int i)
    {
        if (i < 1 || i > 13)
            throw new ArgumentException("Standard Ranks are expected in the range of 1 - 13");
        switch (i)
        {
            case 1:
                return "Ace";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
            case 10:
                return "Ten";
            case 11:
                return "Jack";
            case 12:
                return "Queen";
            case 13:
                return "King";
        }
        return "";
    }
    public static int ConvertIntToStandardValue(int i)
    {
        if (i < 1 || i > 13)
            throw new ArgumentException("Standard Ranks are expected in the range of 1 - 13");
        if (i > 10)
            return 10;
        return i;
    }
}