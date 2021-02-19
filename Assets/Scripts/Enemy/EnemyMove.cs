using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform LeftPoint;
    public Transform RightPoint;
    public float moveSpeed=5.0f;
    public bool isLeft=true;
    public bool isRotated = false;

    float left;
    float right;
    bool isDead=false;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if(isRotated)
            {
                MoveX();
                FlipX();
            }
            else
            {
                MoveZ();
                FlipZ();
            }
        }

    }
    void MoveZ()
    {
        left=transform.parent.InverseTransformPoint(LeftPoint.position).z;
        right=transform.parent.InverseTransformPoint(RightPoint.position).z;
        Vector3 pos=transform.position;
        pos = transform.parent.InverseTransformPoint(pos);
        if(isLeft)
        {
            pos.z+=moveSpeed*Time.deltaTime;
            if(pos.z>=left)
            {
                pos.z=left;
                isLeft=false;
            }
        }
        else
        {
            pos.z-=moveSpeed*Time.deltaTime;
            if(pos.z<=right)
            {
                pos.z=right;
                isLeft=true;
            }
        }
        transform.position=transform.parent.TransformPoint(pos);

    }
    void MoveX()
    {
        left=transform.parent.InverseTransformPoint(LeftPoint.position).x;
        right=transform.parent.InverseTransformPoint(RightPoint.position).x;
        Vector3 pos=transform.position;
        pos = transform.parent.InverseTransformPoint(pos);
        // Debug.Log(left);
        if(isLeft)
        {
            pos.x+=moveSpeed*Time.deltaTime;
            if(pos.x>=left)
            {
                pos.x=left;
                isLeft=false;
            }
        }
        else
        {
            pos.x-=moveSpeed*Time.deltaTime;
            if(pos.x<=right)
            {
                pos.x=right;
                isLeft=true;
            }
        }
        transform.position=transform.parent.TransformPoint(pos);

    }
    void FlipZ()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        if(isLeft)
        {
            rot.y=0;
        }
        else
        {
            rot.y=180;
        }
        transform.localRotation = Quaternion.Euler(rot);
    }
    void FlipX()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        if(isLeft)
        {
            rot.y=90;
        }
        else
        {
            rot.y=-90;
        }
        transform.localRotation = Quaternion.Euler(rot);
    }
}
