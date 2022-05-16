using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class AnimationController : MonoBehaviour
{
    [Header("Sceleton animation")]
    [SerializeField] private SkeletonAnimation _skeletonAnimation;

    [Header("Animations")]
    [SerializeField] private AnimationReferenceAsset _idleAnimation;
    [SerializeField] private AnimationReferenceAsset _moveAnimation;
    [SerializeField] private AnimationReferenceAsset _castAnimation;
    [SerializeField] private AnimationReferenceAsset _hitAnimation;
    [SerializeField] private AnimationReferenceAsset _deathAnimation;


    public SkeletonAnimation SkeletonAnimation { get { return _skeletonAnimation; } }
    public AnimationReferenceAsset IdleAnimation { get { return _idleAnimation; } }
    public AnimationReferenceAsset MoveAnimation { get { return _moveAnimation; } }
    public AnimationReferenceAsset CastAnimation { get { return _castAnimation; } }
    public AnimationReferenceAsset HitAnimation { get { return _hitAnimation; } }
    public AnimationReferenceAsset DeathAnimation { get { return _deathAnimation; } }


    /// <summary>
    /// Set looping animation
    /// </summary>
    /// <param name="animationToSet">Animation reference</param>
    public Spine.TrackEntry PlayAnimation(AnimationReferenceAsset animationToSet)
    {
        Spine.TrackEntry trackEntry = _skeletonAnimation.state.SetAnimation(0, animationToSet, true);
        _skeletonAnimation.timeScale = 1;

        return trackEntry;
    }


    /// <summary>
    /// Set animation
    /// </summary>
    /// <param name="animationToSet">Animation reference</param>
    /// <param name="loop">Is looping</param>
    /// <param name="timeScale">Animation time scale</param>
    public Spine.TrackEntry PlayAnimation(AnimationReferenceAsset animationToSet, bool loop, float timeScale)
    {
        Spine.TrackEntry trackEntry = _skeletonAnimation.state.SetAnimation(0, animationToSet, loop);
        _skeletonAnimation.timeScale = timeScale;

        return trackEntry;
    }
}