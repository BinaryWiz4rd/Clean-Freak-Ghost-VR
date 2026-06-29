using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample {
public class GhostScript : MonoBehaviour
{
    private Animator Anim;
    private CharacterController Ctrl;
    private Vector3 MoveDirection = Vector3.zero;

    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int DissolveState = Animator.StringToHash("Base Layer.dissolve");

    [SerializeField] private SkinnedMeshRenderer[] MeshR;
    private float Dissolve_value = 1;

    void Start()
    {
        Anim = this.GetComponent<Animator>();
        Ctrl = this.GetComponent<CharacterController>();
        
        if (Anim != null)
        {
            Anim.CrossFade(IdleState, 0.1f, 0, 0);
        }
    }

    void Update()
    {
        GRAVITY();
    }

    private void GRAVITY ()
    {
        if(Ctrl != null && Ctrl.enabled)
        {
            if(CheckGrounded())
            {
                if(MoveDirection.y < -0.1f)
                {
                    MoveDirection.y = -0.1f;
                }
            }
            MoveDirection.y -= 0.1f;
            Ctrl.Move(MoveDirection * Time.deltaTime);
        }
    }

    private bool CheckGrounded()
    {
        if (Ctrl == null) return false;

        if (Ctrl.isGrounded && Ctrl.enabled)
        {
            return true;
        }
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        float range = 0.2f;
        return Physics.Raycast(ray, range);
    }
}
}