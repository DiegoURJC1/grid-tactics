using UnityEngine;

[CreateAssetMenu(fileName = "NewAIPlayer", menuName = "Match/Player/AI Player")]
public class AIPlayer : Player
{
    public override bool IsAI => true;

    [Header("AI Behavior Settings")]
    [Tooltip("Delay in seconds between individual actions to make the AI moves watchable.")]
    [SerializeField] private float actionDelay = 0.5f;

    /// <summary>
    /// Event fired when the AI starts its turn decision-making loop.
    /// This is typically handled by a MonoBehaviour manager or controller starting a coroutine.
    /// </summary>
    public event System.Action OnAIThinkStarted;

    public float ActionDelay => actionDelay;

    public override void StartTurn()
    {
        base.StartTurn();
        
        // Notify the game environment (e.g., the MatchManager or AIController) 
        // that this AI player has started its thinking cycle.
        OnAIThinkStarted?.Invoke();
    }

    public override void EndTurn()
    {
        base.EndTurn();
    }
}
