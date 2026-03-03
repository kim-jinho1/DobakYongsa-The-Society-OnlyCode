namespace Member.kJH.Code.Stat
{
    public interface IModifierStat
    {
        void PlusValue(int value);
        void MultiplyValue(int value);
        void SubtractValue(int value);
        void PlusPerScentValue(int value);
        void MinusPerScentValue(int value);
    }
}