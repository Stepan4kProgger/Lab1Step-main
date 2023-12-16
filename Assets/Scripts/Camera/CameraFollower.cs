using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private Transform _player;
    
    private void Start()
    {
        _player = _playerMover.transform;
    }
    
    private void LateUpdate()
    {
        transform.position = _player.position;
        transform.rotation = _player.rotation;
    }
   
}
