
using VotingSystem.Application.Validator;
using VotingSystem.Domin;

namespace VotingSystem.Application
{
    public class VotingSystemService
    {
        uint voterId;
        List<Voter> voterList;

        public VotingSystemService()
        {
            // voterList = null;
            voterId = 8790;
            voterList = new List<Voter>();
        }

        // DRY => do not repeat yourself

        public Voter AddVoter(Voter voter)
        {

            if(VoterValidator.ValidateVoter(voter) == false)
            {
                return null;
            }

            // Create an UUID for voter
            
            voterId = voterId + 1;
            voter.voterId = voterId;
            voterList.Add(voter);
            return voter;
        }

        public Boolean DeleteVoterById(uint vid)
        {
            /** Remove voter from voterList *
             * using voter */
            Voter v = voterList.Find(voter => voter.voterId == vid);
            if(v == null)
            {
                return false;
            }
            voterList.Remove(v);
            return true;
        }

        public Voter GetVoterById(uint v)
        {
           return voterList.Find(voter => voter.voterId == v);
        }

        public List<Voter> GetVoters()
        {
            if(voterList.Count == 0)
            {
                return null;
            }
            return voterList;
        }

        public Voter UpdateVoter(Voter voter)
        {
            /** Update voter in voterList *
             *using voter */
            Voter v = voterList.Find(voter => voter.voterId == voter.voterId);
            if(v == null)
            {
                return null;
            }

            /* Validate the Voter */
            if(VoterValidator.ValidateVoter(voter) == false)
            {
                return null;
            }


            /* Replace voter in voterList */
            voterList.Remove(v);
            voterList.Add(voter);

            return v;

        }
    }
}
