
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
        public Voter AddVoter(Voter voter)
        {
            if(voter.voterName == "")
            {
                return null;
            }

            // Create an UUID for voter
            
            voterId = voterId + 1;
            voter.voterId = voterId;
            voterList.Add(voter);
            return voter;
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
    }
}
