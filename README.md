# UnityRandomNumbers
Simple utility classes that help generate random numbers between [min-max] values + a simple custom PropertyDrawer

# How to use
- Simply declare a ```` RandomFloat ```` or a ```` RandomInt```` variable
- Assign it to the respective float or int variable to get a random variable or use ```` _RandomFloat.Value ```` to work with the value on the spot

# Example 
````

  public class Player : Character
  {
      public RandomFloat DropRateChanceRange;

      [SerializeField]
      private float DropRate;

      private void Awake()
      {
          DropRate = DropRateChanceRange;
      }

  }
````

# Editor view :

![Editor view](https://raw.githubusercontent.com/ahmedhoussem/UnityRandomNumbers/images/editor.PNG)

