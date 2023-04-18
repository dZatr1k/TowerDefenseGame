public static class UnlockCardsData
{
    private static int _unclockCardsCount = 8;

    public static int UnlockCardsCount
    {
        get { return _unclockCardsCount; }
        set 
        { 
            if(value > 9)
                _unclockCardsCount = 9;
            else
                _unclockCardsCount = value;
        }
    }
}
