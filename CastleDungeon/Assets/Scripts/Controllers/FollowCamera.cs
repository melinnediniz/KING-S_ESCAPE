using UnityEngine;

namespace Controllers
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float yOffset = 1f;
        public Transform player;
        // Update is called once per frame
        void Update()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            if(player)
            {
                var position = player.position;
                Vector3 playerPos = new Vector3(position.x, position.y + yOffset, -10f);
                transform.position = Vector3.Slerp(transform.position, playerPos, speed * Time.deltaTime);
            }
        }
    }
}
