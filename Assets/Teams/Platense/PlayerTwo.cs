using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Platense
{
    public class PlayerTwo : TeamPlayer
    {
        private const float minimumDistanceToGoal = 7;
         private bool BallIsNearGoal(Vector3 ballPosition) => 
            Vector3.Distance(ballPosition, GetMyGoalPosition()) < minimumDistanceToGoal;

        public override void OnUpdate()
        {
           var ballPosition = GetBallPosition();
           
            if (BallIsNearGoal(ballPosition))
                MoveBy(GetDirectionTo(ballPosition));
            else
                GoTo(Vector3.Lerp(ballPosition, GetMyGoalPosition(), 0.8f));
        }
         public Vector3 GetTeamMatePosition(int playerIndex)
        {
            return GetTeamMatesInformation()[playerIndex].Position;
        }
        public override void OnReachBall()
           {
            var vegasPosition = GetTeamMatePosition(0);
            ShootBall(GetDirectionTo(vegasPosition),ShootForce.High);
           } 
        
        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.A2;

        public override string GetPlayerDisplayName() => "Ivan";
    }
}