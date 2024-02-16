using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualController : MonoBehaviour
{

    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoveValues(float dir, float speed)
    {
        anim.SetFloat("Direction", dir);
        anim.SetFloat("Speed", speed);

    }
}
