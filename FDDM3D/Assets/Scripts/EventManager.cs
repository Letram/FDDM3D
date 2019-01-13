using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void BulletAction();
    public static event BulletAction onShotFinished;
    public static event BulletAction onBulletDestroyed;

    public delegate void BulletActionData(int data);
    public static event BulletActionData onGainStrength;

    public delegate void WallAction();
    public static event WallAction onWallDestroyed;
    public static void pubBulletDestroyed()
    {
        if (onBulletDestroyed != null)
            onBulletDestroyed();
    }
    public static void pubShotsChanged()
    {
        if (onShotFinished != null)
            onShotFinished();
    }

    public static void pubGainStrength(int data)
    {
        if (onGainStrength != null)
            onGainStrength(data);
    }

    public static void pubWallDestroyed()
    {
        if (onWallDestroyed != null)
            onWallDestroyed();
    }
}
