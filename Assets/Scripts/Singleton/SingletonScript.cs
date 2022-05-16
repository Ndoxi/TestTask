using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonScript : MonoBehaviour
{
    public static SingletonScript Instance;

    [Header("Palyer game object")]
    [SerializeField] private GameObject _playerGameObject;

    public GameObject Player { get { return _playerGameObject; } }


    private void OnEnable()
    {
        Instance = this;
    }
}
