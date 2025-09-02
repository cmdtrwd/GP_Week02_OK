using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Crunch", true);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crunch", false);
        }

    }
}
