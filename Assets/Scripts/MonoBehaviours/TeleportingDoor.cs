using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingDoor : Interactable
{
    [SerializeField] TeleportingDoor _destinationDoor;
    Transform _groundLevel;

    PlayerController _player;

    public void CatchPlayer(Transform playerTransform)
    {
        playerTransform.position = new Vector2(transform.position.x, _groundLevel.position.y);
    }

    protected override void PerformInteraction()
    {
        EnvironmentEvents.FadeInCompleted += OnFadeInCompleted;
        EnvironmentEvents.InvokePlayerTeleporting(); 
    }
    
    void OnFadeInCompleted()
    {
        TeleportPlayer();
        EnvironmentEvents.FadeInCompleted -= OnFadeInCompleted;
    }

    void TeleportPlayer()
    {
        if (_player == null)
            _player = FindObjectOfType<PlayerController>();

        _destinationDoor.CatchPlayer(_player.transform);
        EnvironmentEvents.InvokePlayerTeleported();
    }

    void OnDrawGizmos()
    {
        if (_destinationDoor == null)    
            return;

        var offset = new Vector3(0f, -1f, 0f);
        if (name.ToLower().Contains("left"))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, _destinationDoor.transform.position);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + offset, _destinationDoor.transform.position + offset);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        _groundLevel = GetComponentInParent<RoomAttendant>().GroundLevel;
    }

}
