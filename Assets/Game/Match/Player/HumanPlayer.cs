using UnityEngine;

[CreateAssetMenu(fileName = "NewHumanPlayer", menuName = "Match/Player/Human Player")]
public class HumanPlayer : Player
{
    public override bool IsAI => false;

    public override void StartTurn()
    {
        base.StartTurn();
    }

    public override void EndTurn()
    {
        // Lock player inputs, hide selection indicators, etc.
        base.EndTurn();
    }
}
