using System;

[Serializable]
public class RandomFloat
{
    static readonly Random _seed = new Random();

    public float Max;
    public float Min;

    [UnityEngine.Tooltip("Set this to true if you want a constant value instead of a new value each time")]
    public bool OneShotMode;

    private bool isSet;
    private float OneShotValue;

    public float Value
    {
        get
        {
            if (!OneShotMode)
                return (float)(_seed.NextDouble() * (Max - Min) + Min);
            if (!isSet)
            {
                OneShotValue = (float)(_seed.NextDouble() * (Max - Min) + Min);
                isSet = true;
            }
            return OneShotValue;

        }
    }


    public RandomFloat(float MinValue, float MaxValue, bool isOneShotMode)
    {
        Max = MaxValue;
        Min = MinValue;
        OneShotMode = isOneShotMode;
    }

    public static implicit operator float(RandomFloat d)
    {
        return d.Value;
    }
}
