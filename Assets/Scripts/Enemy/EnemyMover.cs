using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _patroulingSpeed;

    private Rigidbody _rigidbody;

    private Vector3 _firstPatroulPoint;
    private Vector3 _secondPatroulPoint;

    private Vector3 _currentPatroulPoint;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator Patrouling()
    {
        while (gameObject.activeSelf)
        {
            Vector3 moveDirection = transform.forward;
            _rigidbody.velocity = moveDirection * _patroulingSpeed;
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("rotating");
        transform.Rotate(0f, 90f, 0f);
    }

    public void StartPatroul()
    {
        StartCoroutine(Patrouling());
    }
}