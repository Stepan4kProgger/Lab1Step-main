using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private ShotHole holePrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                enemy.Destroy();
            if (hit.collider.CompareTag("Wall"))
            {
                var l = hit.point + hit.normal * 0.001f;
                
                var new_hole = Instantiate(holePrefab, l, Quaternion.identity);
                new_hole.transform.LookAt(hit.normal + hit.point);
            }
        }
    }
}