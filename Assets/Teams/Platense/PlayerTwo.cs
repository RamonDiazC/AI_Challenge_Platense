using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Platense
{
    public class PlayerTwo : TeamPlayer
    {
        private const float minimumDistanceToGoal = 6;
         private bool BallIsNearGoal(Vector3 ballPosition) => 
            Vector3.Distance(ballPosition, GetMyGoalPosition()) < minimumDistanceToGoal;

        public override void OnUpdate()
        {
           var ballPosition = GetBallPosition();

            if (BallIsNearGoal(ballPosition))
                MoveBy(GetDirectionTo(ballPosition));
            else
                GoTo(FieldPosition.A2);
        }

        public override void OnReachBall() =>
            ShootBall(GetDirectionTo(GetRivalGoalPosition()), ShootForce.High);
        
        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.A2;

        public override string GetPlayerDisplayName() => "Ivan";
    }
}