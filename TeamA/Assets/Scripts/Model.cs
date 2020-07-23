using UnityEngine;

namespace DefaultNamespace
{
    public class Model : MonoBehaviour
    {
        private Animator animator;
        // Use this for initialization
        void Start () {
            animator = GetComponent<Animator>();
            animator.SetBool("Grounded", true);
        }

        // Update is called once per frame
        void Update () {
            if (Input.GetKey("up")) {
                transform.position += transform.forward * 0.05f;
                animator.SetBool("reaction", true);
            } else {
                animator.SetBool("Grounded", true);
            }
            if (Input.GetKey("right")) {
                transform.Rotate(0, 10, 0);
            }
            if (Input.GetKey ("left")) {
                transform.Rotate(0, -10, 0);
            }
        }
    }
}