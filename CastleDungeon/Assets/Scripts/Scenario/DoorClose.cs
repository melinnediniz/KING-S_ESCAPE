using UnityEngine;

namespace Scenario
{
    public class DoorClose : MonoBehaviour
    {   
        private Animator Anim;
        // Start is called before the first frame update
        void Start()
        {
            Anim = GetComponent<Animator>();
            Anim.SetTrigger("door_out");
        }

    }
}
