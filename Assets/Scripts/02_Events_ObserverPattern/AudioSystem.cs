using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour 
{
    private void OnEnable() => SkeletonKing.OnBossDead += SkeletonKing_OnBossDead;
    private void OnDisable() => SkeletonKing.OnBossDead -= SkeletonKing_OnBossDead;
    private void SkeletonKing_OnBossDead() => PlayVictoryMusic();
    public void PlayVictoryMusic() => Debug.Log("Playing Victory Music!");
}
