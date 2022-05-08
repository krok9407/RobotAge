
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class lookAtIK : MonoBehaviour
{
    protected Animator animator;
    public bool ikActivate = false;
    public Transform lookObj = null;
        void Start()
    {
        animator = GetComponent<Animator>();
    }
private void OnAnimatorIK(){
    if(animator){
        if(ikActivate){
            if(lookObj != null){
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(lookObj.position);
            }
        }
        else{
            animator.SetLookAtWeight(0);
        }
    }
}
}
