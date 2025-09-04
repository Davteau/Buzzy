public interface IRandomNumberService
{
    int Number { get; }
}

public interface ISingletonRandom : IRandomNumberService { }
public interface IScopedRandom : IRandomNumberService { }
public interface ITransientRandom : IRandomNumberService { }

public class RandomNumberService :
    ISingletonRandom,
    IScopedRandom,
    ITransientRandom
{
    public int Number { get; }

    public RandomNumberService()
    {
        Number = Random.Shared.Next(1, 1000);
    }
}
