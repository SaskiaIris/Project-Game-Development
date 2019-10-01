using UnityEngine;

public class AnimatorStateController : StateMachineBehaviour
{
    public bool enter;
    public bool exit;
    public bool setAttackBool;

    // This will be called once the animator has transitioned out of the state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (exit)
            return;
        
        //Debug.Log("State enter");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().anim.SetBool("attacking", true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (enter)
            return;

        //Debug.Log("State exit");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().anim.SetBool("attacking", false);
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (exit)
            return;

        //Debug.Log("State move");
        //FindObjectOfType<StasisCharacter>().anim.SetBool("attacking", setAttackBool);
    }
}
