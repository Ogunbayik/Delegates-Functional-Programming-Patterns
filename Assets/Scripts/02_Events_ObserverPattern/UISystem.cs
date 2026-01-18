using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private GameObject _victoryPanel;

    private void OnEnable() => SkeletonKing.OnBossDead += SkeletonKing_OnBossDead;
    private void OnDisable() => SkeletonKing.OnBossDead -= SkeletonKing_OnBossDead;        
    private void SkeletonKing_OnBossDead() => ToggleVictoryPanel(true);
    public void ToggleVictoryPanel(bool isActive) => _victoryPanel.SetActive(isActive);
}
