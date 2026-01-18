using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievmentSystem : MonoBehaviour
{
    private void OnEnable() => SkeletonKing.OnBossDead += SkeletonKing_OnBossDead;
    private void OnDisable() => SkeletonKing.OnBossDead -= SkeletonKing_OnBossDead;
    private void SkeletonKing_OnBossDead() => UnlockAchievment("SLAYER KING!");
    private void UnlockAchievment(string achievment) => Debug.Log($"Unlocked {achievment}!");
}
