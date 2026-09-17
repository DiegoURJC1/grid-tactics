using System;
using Game.Match.Unit.UnitComponent;

public sealed class FuelTank : IUnitComponent
{
	public int Capacity { get; }
	public int Current { get; private set; }
	public bool ConsumesPerTurn { get; } // p.ej. aviones sí, tanques no

	public FuelTank(int capacity, bool consumesPerTurn)
	{
		Capacity = capacity;
		Current = capacity;
		ConsumesPerTurn = consumesPerTurn;
	}

	public bool Consume(int amount)
	{
		if (Current < amount) return false;
		Current -= amount;
		return true;
	}

	public void Refill(int amount) => Current = Math.Min(Capacity, Current + amount);
}