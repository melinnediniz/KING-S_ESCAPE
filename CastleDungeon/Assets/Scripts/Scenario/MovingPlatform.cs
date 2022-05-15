using UnityEngine;

namespace Scenario
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]private float speed;
        [SerializeField] private float moveTime;

        private bool _dirRight;
        private float _timer;
        void Update()
        {
            if(_dirRight){
                transform.Translate(Vector2.right * (speed * Time.deltaTime));
            }else{
                transform.Translate(Vector2.left * (speed * Time.deltaTime));
            }

            _timer += Time.deltaTime;
        
            if(_timer >= moveTime){
                _dirRight = !_dirRight;
                _timer = 0f;
            }

        }
    }
}
