using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    interface ITransfer
    {       
        void MakeTransfer(int playerId, int teamId);
    }
}
