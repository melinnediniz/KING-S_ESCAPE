using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField] private float yOffset;
    public Transform player;

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player)
        {
            Vector3 position = player.position;
            Vector3 playerPos = new Vector3(position.x, position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, playerPos, speed * Time.deltaTime);
        }
    }
}
