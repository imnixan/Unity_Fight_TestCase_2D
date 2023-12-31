﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game balance parametres")]
    [SerializeField]
    private Balance balanceData;

    [Space]
    [Header("Prefabs")]
    [SerializeField]
    private Player player;

    [SerializeField]
    private Enemy enemyPrefab;

    [Space]
    [Header("Other modules")]
    [SerializeField]
    private EndGameUI gameUI;

    [SerializeField]
    private Transform enemyParent;

    private Enemy enemy;

    private void Start()
    {
        enemy = Instantiate(enemyPrefab, enemyParent);
        enemy.tag = "Enemy";
        enemy.Init(
            Random.Range(balanceData.minEnemyHp, balanceData.maxEnemyHp + 1),
            CrossSceneInfo.EnemyName
        );
        enemy.EnemyKilled += OnEnemyKilled;

        player.Init(balanceData);
    }

    private void OnEnemyKilled()
    {
        enemy.EnemyKilled -= OnEnemyKilled;
        int reward = Random.Range(balanceData.minReward, balanceData.maxReward + 1);
        player.AddReward(reward);
        gameUI.EndGame(reward);
    }
}
