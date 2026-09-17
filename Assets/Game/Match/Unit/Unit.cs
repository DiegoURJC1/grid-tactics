#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Game.Match.Unit.UnitComponent;
using UnityEngine;

public abstract class Unit
{
	public string Id { get; }
	public Player Owner { get; set; }
	//public UnitDefinition Definition { get; } // datos "de fábrica": HP máx, coste, etc.

	public int CurrentHP { get; private set; }
	public int Fatigue { get; internal set; }
	//public UnitStatus Status { get; internal set; } = UnitStatus.Active;

	//public IMovementProfile Movement { get; }
	public List<IWeapon> Weapons { get; } = new();
	private readonly List<IUnitComponent> _components = new();

	// Posición: solo lectura pública, mutable únicamente por el Board (sección 10)
	public Vector2Int Position { get; internal set; }
	/*
	protected Unit(UnitDefinition def, IMovementProfile movement)
	{
		Definition = def;
		CurrentHP = def.MaxHP;
		Movement = movement;
	}
	*/
	public T? GetComponent<T>() where T : class, IUnitComponent
		=> _components.OfType<T>().FirstOrDefault();

	public void AddComponent(IUnitComponent c) => _components.Add(c);

	/*
	public virtual void TakeDamage(int amount)
	{
		CurrentHP = Math.Max(0, CurrentHP - amount);
		if (CurrentHP == 0) Status = UnitStatus.Destroyed;
	}

	// Cada acción disponible se pregunta a sí misma si es válida (ver sección 8)
	public virtual IEnumerable<IAction> GetAvailableActions(GameState state)
		=> ActionCatalog.For(this).Where(a => a.CanExecute(new ActionContext(this, state)));

	// Ganchos de Template Method para comportamientos especiales por subtipo
	protected internal virtual void OnActivationStart(GameState state) { }
	protected internal virtual void OnActivationEnd(GameState state) { }
	*/
}