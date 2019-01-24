using System;
using DALModel;

namespace BLL
{
    public class Transfer : ITransfer
    {
        IUnitOfWork context;

        public Transfer(IUnitOfWork db)
        {
            context = db;
        }

        public void MakeTransfer(int playerId, int teamId)
        {
            Players player = context.PlayersRepository.GetByID(playerId);
            Teams team = context.TeamsRepository.GetByID(teamId);

            if (player == null || team == null )
            {
                throw new NullReferenceException("Id is incorrect");
            }

            if (player.TeamId == teamId)
            {
                throw new ArgumentException("The player is already in the team with that id!!!");
            }

            player.TeamId = team.Id;
            context.Save();
        }
    }
}
