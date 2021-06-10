using Core.Games;
using Core.Player;
using JetBrains.Annotations;
using UnityEngine;

namespace Teams.Platense
{
    [UsedImplicitly]
    public class ParticipantTeam : Team
    {
        public TeamPlayer GetPlayerOne() => new PlayerOne();

        public TeamPlayer GetPlayerTwo() => new PlayerTwo();

        public TeamPlayer GetPlayerThree() => new PlayerThree();
        
        public Color PrimaryColor => new Color(0.6f, 0.6f, 0.6f);

        public string GetName() => "Platense";

        public string TeamShield => "Green";


    }
}