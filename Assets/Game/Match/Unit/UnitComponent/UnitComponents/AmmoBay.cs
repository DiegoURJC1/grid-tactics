using Game.Match.Unit.UnitComponent;

public sealed class AmmoBay : IUnitComponent
{
	public int Capacity { get; }
	public int Current { get; private set; }

	public AmmoBay(int capacity)
	{
		Capacity = capacity;
		Current = capacity;
	}

	public bool Consume(int amount)
	{
		if (Current < amount) return false;
		Current -= amount;
		return true;
	}

	public void Refill() => Current = Capacity;
}