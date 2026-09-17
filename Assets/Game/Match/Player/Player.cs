using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : ScriptableObject
{
    [Header("Player Details")]
    [SerializeField] private string playerName = "New Player";
    [SerializeField] private Color playerColor = Color.red;

    [Header("Economy")]
    [SerializeField] private int funds = 0;

    private readonly List<Unit> activeUnits = new List<Unit>();

    // Events for turn management and state changes
    public event Action OnTurnStarted;
    public event Action OnTurnEnded;
    public event Action<int> OnFundsChanged;
    public event Action<Unit> OnUnitRegistered;
    public event Action<Unit> OnUnitUnregistered;

    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }

    public Color PlayerColor
    {
        get => playerColor;
        set => playerColor = value;
    }

    public int Funds
    {
        get => funds;
        protected set
        {
            if (funds != value)
            {
                funds = value;
                OnFundsChanged?.Invoke(funds);
            }
        }
    }

    public IReadOnlyList<Unit> ActiveUnits => activeUnits;

    /// <summary>
    /// Indicates whether this player is controlled by AI.
    /// </summary>
    public abstract bool IsAI { get; }

    /// <summary>
    /// Called by the turn manager to initiate the player's turn.
    /// </summary>
    public virtual void StartTurn()
    {
        OnTurnStarted?.Invoke();
    }

    /// <summary>
    /// Called when the player finishes their turn.
    /// </summary>
    public virtual void EndTurn()
    {
        OnTurnEnded?.Invoke();
    }

    /// <summary>
    /// Adds funds to the player's treasury (e.g., from capturing cities or turn income).
    /// </summary>
    public virtual void AddFunds(int amount)
    {
        if (amount < 0) return;
        Funds += amount;
    }

    /// <summary>
    /// Deducts funds if the player has enough. Returns true if successful.
    /// </summary>
    public virtual bool SpendFunds(int amount)
    {
        if (amount < 0 || Funds < amount) return false;
        Funds -= amount;
        return true;
    }

    /// <summary>
    /// Registers a unit to this player.
    /// </summary>
    public virtual void RegisterUnit(Unit unit)
    {
        if (unit == null) return;
        if (!activeUnits.Contains(unit))
        {
            activeUnits.Add(unit);
            unit.Owner = this;
            OnUnitRegistered?.Invoke(unit);
        }
    }

    /// <summary>
    /// Unregisters a unit from this player (e.g., when the unit is destroyed).
    /// </summary>
    public virtual void UnregisterUnit(Unit unit)
    {
        if (unit == null) return;
        if (activeUnits.Remove(unit))
        {
            if (unit.Owner == this)
            {
                unit.Owner = null;
            }
            OnUnitUnregistered?.Invoke(unit);
        }
    }
}
