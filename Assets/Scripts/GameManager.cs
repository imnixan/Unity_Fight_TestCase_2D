﻿using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private Player player;

    [Space]
    [Header("Enemy")]
    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private float minEnemyHp;

    [SerializeField]
    private float maxEnemyHp;

    [Space]
    [Header("Reward")]
    [SerializeField]
    private int minReward;

    [SerializeField]
    private int maxReward;

    [Space]
    [Header("Other modules")]
    [SerializeField]
    private GameUI gameUI;

    [SerializeField]
    private Transform enemyParent;

    private Enemy enemy;

    private void Start()
    {
        enemy = Instantiate(enemyPrefab, enemyParent);
        enemy.tag = "Enemy";
        enemy.Init(Random.Range(minEnemyHp, maxEnemyHp));
        enemy.EnemyKilled += OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        enemy.EnemyKilled -= OnEnemyKilled;
        player.AddReward(Random.Range(minReward, maxReward));
        gameUI.EndGame();
    }
}