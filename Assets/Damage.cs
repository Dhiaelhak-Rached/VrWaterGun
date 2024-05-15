using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Damage : MonoBehaviour, ITakeDamage
{
    public GameObject cubePrefab; // Reference to the cube prefab you want to spawn

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        rigidBody.AddForce(projectile.transform.forward * weapon.GetShootingForce(), ForceMode.Impulse);
        Destroy(gameObject);
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
