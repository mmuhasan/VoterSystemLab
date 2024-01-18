using VotingSystem.Application;
using VotingSystem.Domin;

namespace VotingSystem.UnitTests.Application
{
    public class VotingSystemServiceTest
    {

        [Fact]
        void VotingSystem_ReturnEmpty_WhenCreated()
        {
            // Arrange
            VotingSystemService service = new VotingSystemService();

            // Act
            var list = service.GetVoters();

            // Assert
            Assert.Null(list);
        }

        [Fact]
        void GetVoter_ReturnNotEmpty_AfterAddVoter()
        {
            // Arrange
            VotingSystemService service = new VotingSystemService();
            Voter voter = new Voter();

            // Act
            service.AddVoter(voter);
            var list = service.GetVoters();

            // Assert
            Assert.NotNull(list);
        }

        [Fact]
        void AddVoter_ReturnVoterWithID_AfterAddVoterSuccess()
        {
            // Arrange
            VotingSystemService service = new VotingSystemService();
            Voter voter = new Voter();

            // Act
            Voter rVoter = service.AddVoter(voter);

            // Assert
            Assert.NotEqual<uint>(0,rVoter.voterId);
        }

        [Fact]
        void AddVoter_ReturnNull_IfVoterNameIsEmpty()
        {
            // Arrange
            VotingSystemService service = new VotingSystemService();
            Voter voter = new Voter()
            {
                voterName = ""
            };

            // Act
            Object rVoter = service.AddVoter(voter);

            // Assert
            Assert.Null(rVoter);
        }

        [Fact]
        void AddVoter_ReturnUniqueVoterID_AfterAddTwoVote()
        {
            // Arrange
            VotingSystemService service = new VotingSystemService();
            Voter voter1 = new Voter()
            {
                voterName = "voter1"
            };
            Voter voter2 = new Voter()
            {
                voterName = "voter2"
            };

            // Act
            Voter rVoter1 = service.AddVoter(voter1);
            Voter rVoter2 = service.AddVoter(voter2);

            // Assert
            Assert.NotEqual<uint>(rVoter1.voterId,rVoter2.voterId);
        }

        [Fact]
        void GetVoterById_ReturnNull_IfNotExists()
        {
            // Arrange
            VotingSystemService service = new VotingSystemService();
            
            // Act
            Voter rVoter = service.GetVoterById(1);

            // Assert
            Assert.Null(rVoter);

        }

        [Fact]
        void GetVoteById_ReturnVoter_IfExists() 
        { 
            //Act
            VotingSystemService service = new VotingSystemService();
            Voter voter = new Voter()
            {
                voterName = "voter1",
                voterAddress = "voter address",
                voterDOB = DateTime.Now,
                voterEmail = "myemail@email.com"
            };

            //Act
            Voter retVoter = service.AddVoter(voter);
            Voter rVoter = service.GetVoterById(retVoter.voterId);


            //Assert
            Assert.NotNull(rVoter);
            Assert.Equal(voter.voterName, rVoter.voterName);
            Assert.Equal(voter.voterAddress, rVoter.voterAddress);
            Assert.Equal(voter.voterDOB, rVoter.voterDOB);
            Assert.Equal(voter.voterEmail, rVoter.voterEmail);        
        }

        [Fact]
        void GetVoters_ReturnTwoVoters_AfterAddTwoVoters()
        {
            //Arrange
            VotingSystemService service = new VotingSystemService();
            Voter voter1 = new Voter()
            {
                voterName = "voter1",
                voterAddress = "voter address",
                voterDOB = DateTime.Now,
                voterEmail = ""
            };
            Voter voter2 = new Voter()
            {
                voterName = "voter2",
                voterAddress = "voter address",
                voterDOB = DateTime.Now,
                voterEmail = ""
            };

            //Act
            Voter v1 = service.AddVoter(voter1);
            Voter v2 = service.AddVoter(voter2);

            List<Voter> voters = service.GetVoters();


            //Assert
            Assert.NotNull(voters);
            Assert.Equal(2, voters.Count);
        }
    }
}
