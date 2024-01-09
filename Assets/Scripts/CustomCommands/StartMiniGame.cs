using DTT.MinigameMemory;
using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("miniGame")]
public class StartMiniGame : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        MiniGame.Instance.StartMemoryGame();
        return UniTask.CompletedTask;
    }
}