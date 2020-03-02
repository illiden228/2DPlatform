using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsRenderer : MonoBehaviour
{
    [SerializeField] private GameObject _exampleHP;

    public void AddHealth()
    {
        Instantiate(_exampleHP, transform);
    }

    public void RemoveHealth()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
