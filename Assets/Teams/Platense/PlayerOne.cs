using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Platense    
{
    public class PlayerOne : TeamPlayer
    {
        public float getDistanceToBall() 
       {
         return Vector3.Distance(GetPosition(), GetBallPosition() );
       }
       public int getPlayerState(float distance, float threshold)
       {
         if (distance < threshold)
         {
           return 0;
         } else {
           return 1;
         }
       }
        public override void OnUpdate()
        {
          var distanceToBall = getDistanceToBall() ;
          var state = getPlayerState(distanceToBall, 6);
          switch (state) {
            case 0: 
              var ballPosition = GetBallPosition();
              MoveBy(GetDirectionTo(ballPosition));
              break;
            case 1:
              GoTo(FieldPosition.F3);
              break;
          }
        }

        public Vector3 GetTeamMatePosition(int playerIndex)
        {
            return GetTeamMatesInformation()[playerIndex].Position;
        }
        public override void OnReachBall()
        {
          var state = getPlayerState(Vector3.Distance(GetPosition(), GetRivalGoalPosition()), 6);
          switch (state) {
            case 0:
              ShootBall(GetDirectionTo(GetRivalGoalPosition()), ShootForce.High);
              break;
            case 1:
              var midPosition = GetTeamMatePosition(1);
              ShootBall(GetDirectionTo(midPosition),ShootForce.High);
              break;

          }
          
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C2;

        public override string GetPlayerDisplayName() => "Dani Vega";
    }
}