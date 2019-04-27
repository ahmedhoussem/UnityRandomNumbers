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

![](https://raw.githubusercontent.com/ahmedhoussem/UnityRandomNumbers/master/images/editor.PNG)

# OS Mode :
- Toggle "OS Mode" on to get a constant random value that gets generated in the first call and gets returned for every next call
- Toggle "OS Mode" off to get a different value every time

