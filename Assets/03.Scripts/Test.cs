using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;

// Add this to the same GameObject as your SkeletonAnimation
public class Test : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeletonAnimation;

    [SerializeField] SkeletonGraphic skeletonGraphic;

    [SerializeField] SkeletonDataAsset skeletonDataAsset;

    [SerializeField] Sprite s;

    [SerializeField] Material m;

    [SerializeField] MeshRenderer me;

    [SpineEvent] public string head_turnEventName = "head-turn";
    
    void Start()
    {
        //transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
        //Debug.Log(transform.GetComponent<MeshRenderer>().material.color);

        //me.material = m;
        //Debug.Log(me.material.name);

        //me.material.color = new Color(0, 0, 0, 0);
        //Debug.Log(me.material.color);


        //Debug.Log(s.rect.width);
        //Debug.Log(s.rect.height);

        //skeletonAnimation.AnimationState.Event += HandleEvent;

        //skeletonAnimation.AnimationState.Start += delegate (TrackEntry trackEntry) {
        //     You can also use an anonymous delegate.
        //    Debug.Log(string.Format("track {0} started a new animation.", trackEntry.TrackIndex));
        //};

        //skeletonAnimation.AnimationState.End += delegate {
        //     ... or choose to ignore its parameters.
        //    Debug.Log("An animation ended!");
        //};


        skeletonAnimation.AnimationState.SetAnimation(0, "head-turn", false);
        skeletonGraphic.AnimationState.SetAnimation(0, "head-turn", false);

        skeletonGraphic.AnimationState.AddAnimation(0, "run", true, 1f);
        skeletonGraphic.skeletonDataAsset = skeletonDataAsset;

        //skeletonGraphic.color = new Color(0f, 0f, 0f, 0f);
        //skeletonAnimation.AnimationState.SetAnimation(0, "run", false );
    }

    private void Update()
    {
        
    }

    void HandleEvent(TrackEntry trackEntry, Spine.Event e)
    {
        // Play some sound if the event named "footstep" fired.
        if (e.Data.Name == head_turnEventName)
        {
            Debug.Log("Play a footstep sound!");
        }
    }

}