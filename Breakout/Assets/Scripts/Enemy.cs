using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] _cannon;
    [SerializeField]
    private Transform _target;

    [Header("Shooting")]
    [SerializeField]
    private float _timeBetweenBullets = 7f;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private Transform[] _shootPoints;

    private Vector3 _initPos, _endPos;
    private float _fireTimer = 0;

    protected void Start()
    {
    }

    private void OnEnable()
    {
        _fireTimer = _timeBetweenBullets;
    }

    private void Update()
    {
        LookAtTarget();
        TryToShoot();
    }

    private void LookAtTarget()
    {
        if (!_target)
            return;

        foreach (Transform c in _cannon)
        {
            c.up = (_target.position - c.position).normalized;
        }
    }

    private void TryToShoot()
    {
        if (!_target)
            return;

        if (_fireTimer > 0)
            _fireTimer -= Time.deltaTime;

        if (_fireTimer <= 0)
        {
            _fireTimer = _timeBetweenBullets;
            Shoot();
        }

    }

    private void Shoot()
    {
        foreach (Transform s in _shootPoints)
        {
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = s.position;
            projectile.transform.rotation = s.rotation;
        }
    }
}
