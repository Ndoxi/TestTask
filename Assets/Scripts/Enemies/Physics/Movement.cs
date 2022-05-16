using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Movement : MonoBehaviour
{
    [Header("Enemy script manager")]
    [SerializeField] private EnemyScriptManager _scriptManager;

    [Header("NavMesh agent")]
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private GameObject _playerGameObject;
    private EnemyStats _goblinStats;

    public bool IsStoped { 
        get { return _navMeshAgent.isStopped; } 
        set { _navMeshAgent.isStopped = value; } }

    private void Start()
    {
        _playerGameObject = SingletonScript.Instance.Player;
        _goblinStats = _scriptManager.GoblinBehaviour.GoslinStats;

        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }


    public void MoveGoblin()
    {
        if (_navMeshAgent.isStopped) 
        {
            Debug.LogWarning("NavMesh agent is stoped");
            return;
        }

        _navMeshAgent.speed = _goblinStats.speed;
        _navMeshAgent.SetDestination(_playerGameObject.transform.position);

        //Change scrite direction
        if (_navMeshAgent.destination.x > transform.position.x)
        {
            _scriptManager.Visuals.FaceRight();
        } 
        else if (_navMeshAgent.destination.x < transform.position.x)
        {
            _scriptManager.Visuals.FaceLeft();
        }
    }

}