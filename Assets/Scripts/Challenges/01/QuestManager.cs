using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    private const int GOLD_REWARD = 100;

    private Predicate<int> CanAcceptQuest;

    private Func<int, int> CalculateReward;

    private Action<string,int> OnQuestFinished;

    void Start()
    {
        CanAcceptQuest = (playerLevel) => playerLevel >= 10;
        CalculateReward = (mode) => mode * GOLD_REWARD;
        OnQuestFinished = (name, reward) => Debug.Log($"Mission {name} Completed!. Reward: {reward}");

        int playerLevel = 15;
        int difficulty = 3;
        string questName = "Kill the Dragon!";

        if (CanAcceptQuest(playerLevel))
        {
            var reward = CalculateReward(difficulty);
            OnQuestFinished?.Invoke(questName, reward);
        }
        else
        {
            Debug.Log("Player level is not enough for this quest!");
        }
    }
}
