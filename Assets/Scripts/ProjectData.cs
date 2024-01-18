using UnityEngine;

public static class ProjectData
{
    public static class AnimatorTriggers
    {
        public static readonly int AttackHash = Animator.StringToHash("Attack");
        public static readonly int JumpHash = Animator.StringToHash("Jump");
        public static readonly int LandHash = Animator.StringToHash("Land");
        public static readonly int TakeHitHash = Animator.StringToHash("TakeHit");
        public static readonly int DeathHash = Animator.StringToHash("Death");
        public static readonly int VampirismHash = Animator.StringToHash("Vampirism");

    }

    public static class AnimatorParams
    {
        public static readonly int RunStateHash = Animator.StringToHash("IsRunning");
        public static readonly int VampirizableStateHash = Animator.StringToHash("IsVampirizable");
    }

    public static class Axes 
    {
        public static readonly string Horizontal = "Horizontal";
        public static readonly string Vertical = "Vertical";
    }

    public static class Angles
    {
        public static readonly int RightTurnAngle = 180;
        public static readonly int LeftTurnAngle = 0;
    }
}
