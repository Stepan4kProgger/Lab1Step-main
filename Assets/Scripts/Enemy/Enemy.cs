using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    public void Spawn(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        _mover.StartPatroul();
    }
    
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}