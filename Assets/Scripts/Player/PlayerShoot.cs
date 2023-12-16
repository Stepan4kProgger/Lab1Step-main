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
                var hitPosition = hit.point + hit.normal * 0.001f;
                
                var newHole = Instantiate(holePrefab, hitPosition, Quaternion.identity);
                newHole.transform.rotation = Quaternion.FromToRotation(newHole.transform.up, hit.normal) * newHole.transform.rotation;
            }
        }
    }
}