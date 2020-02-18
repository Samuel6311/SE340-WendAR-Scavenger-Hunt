using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using HutongGames.PlayMaker;

public class TrigLoc9 : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    private readonly List<TrackableBehaviour.Status> mTrackableList = new List<TrackableBehaviour.Status>()
    {
        TrackableBehaviour.Status.DETECTED,
        TrackableBehaviour.Status.TRACKED,

        TrackableBehaviour.Status.EXTENDED_TRACKED
    };

    // Start is called before the first frame update
    private void Awake()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        foreach (TrackableBehaviour.Status trackedStatus in mTrackableList)
        { 
            if (newStatus == trackedStatus)
            {
                PlayMakerFSM.BroadcastEvent("TriggerLocation9");
            }
        }
    }
}
