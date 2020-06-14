using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;

// Add this to the same GameObject as your SkeletonAnimation
public class Test : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeletonAnimation;

    [SerializeField] Sprite s;

    [SpineEvent] public string head_turnEventName = "head-turn";
    
    void Start()
    {
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


        //skeletonAnimation.AnimationState.SetAnimation(0, "head-turn", false);
        //skeletonAnimation.AnimationState.SetAnimation(0, "run", false );

        List<Dictionary<string, string>> data = CSVReader.Read("TEST");

        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log("TEST EXP : " + data[i]["Character"] + " TEST BONUS : " + data[i]["Text"]);
        }

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