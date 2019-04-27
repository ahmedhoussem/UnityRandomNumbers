using System;

[Serializable]
public class RandomInt
{
    static readonly Random _seed = new Random();

    public int Max;
    public int Min;

    [UnityEngine.Tooltip("Set this to true if you want a constant value instead of a new value each time")]
    public bool OneShotMode;

    private bool isSet;
    private int OneShotValue;

    public int Value
    {
        get
        {
            if (!OneShotMode)
                return _seed.Next(Min, Max);
            if (!isSet)
            { 
                OneShotValue = _seed.Next(Min, Max);
                isSet = true;
            }
            return OneShotValue;

        }
    }


    public RandomInt(int MinValue, int MaxValue, bool isOneShotMode)
    {
        Max = MaxValue;
        Min = MinValue;
        OneShotMode = isOneShotMode;
    }

    public static implicit operator int(RandomInt d)
    {
        return d.Value;
    }
}
