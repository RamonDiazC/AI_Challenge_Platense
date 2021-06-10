using Core.Games;
using Core.Player;
using Core.Utils;
using UnityEngine;

namespace Teams.Platense
{
    public class PlayerThree : TeamPlayer
    {
        public override void OnUpdate()
        {
            GoTo(FieldPosition.F1);
        }

        public override void OnReachBall()
        {
           
        }

        public override void OnScoreBoardChanged(ScoreBoard scoreBoard)
        {

        }

        public override FieldPosition GetInitialPosition() => FieldPosition.C2;

        public override string GetPlayerDisplayName() => "Player 3";
    }
}