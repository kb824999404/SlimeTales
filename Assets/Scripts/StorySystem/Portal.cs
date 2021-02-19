using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : StoryItemBase
{
    public Transform player;
    public Transform target;
    protected override void executeEvent()
    {
        Debug.Log(text);
        player.position = target.position;
    }

}
