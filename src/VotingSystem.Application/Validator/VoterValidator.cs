using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystem.Domin;

namespace VotingSystem.Application.Validator
{
    public class VoterValidator
    {
        public static bool ValidateVoter(Voter v)
        {
            if(v.voterName == "")
            {
                return false;
            }
            return true;
        }
    }
}
