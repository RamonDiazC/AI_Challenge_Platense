using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Platense
{
    public class PlayerThree : TeamPlayer
    {
     private const float minimumDistanceToGoal = 16;

        public override void OnUpdate()
        {
            var ballPosition = GetBallPosition();

            if (BallIsNearGoal(ballPosition))
                MoveBy(GetDirectionTo(ballPosition));
            else
                GoTo(FieldPosition.C2);
        }

        private bool BallIsNearGoal(Vector3 ballPosition) => 
            Vector3.Distance(ballPosition, GetMyGoalPosition()) < minimumDistanceToGoal;

        public Vector3 GetTeamMatePosition(int playerIndex)
        {
            return GetTeamMatesInformation()[playerIndex].Position;
        }
        
        public override void OnReachBall() 
        {
            var vegasPosition = GetTeamMatePosition(0);
            var distanceToVega = Vector3.Distance(vegasPosition, GetPosition());
            var distanceToRivalsGoal = Vector3.Distance(GetRivalGoalPosition(), GetPosition());
            if (distanceToVega < distanceToRivalsGoal)
                ShootBall(GetDirectionTo(vegasPosition),ShootForce.High);
            else 
                ShootBall(GetDirectionTo(GetRivalGoalPosition()),ShootForce.High);
        } 

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {
        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C2;

        public override string GetPlayerDisplayName() => "Mid";
    }
}