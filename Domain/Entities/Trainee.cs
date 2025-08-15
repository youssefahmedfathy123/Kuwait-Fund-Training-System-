using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Trainee  : Aditable<Guid>
    {

        private int _SickLeave1 = 2; // phase 1
        private int _NormalLeave = 5;  // phase 2   
        private int _SickLeave2 = 4; // phase 2

        public void AggrementSickLeavePhase1(int days) 
        {
            if (_SickLeave1 <= 0)
                throw new Exception("Not valid!");  

            _SickLeave1 -= days;
            if (_SickLeave1 < 0)
            {
                _SickLeave1 += days;
                throw new Exception($"There is {-_SickLeave1} days exceded the maximum,Try again");
            }

        }

        public void AggrementNormalLeavePhase2(int days)
        {
            if (_NormalLeave <= 0)
                throw new Exception("Not valid!");

            _NormalLeave -= days;
            if (_NormalLeave < 0)
            {
                _NormalLeave += days;
                throw new Exception($"There is {-_NormalLeave} days exceded the maximum,Try again");
            }
        }

        public void AggrementSickLeavePhase2(int days)
        {
            if (_SickLeave2 <= 0)
                throw new Exception("Not valid!");

            _SickLeave1 -= days;
            if (_SickLeave2 < 0)
            {
                _SickLeave2 += days;
                throw new Exception($"There is {-_SickLeave2} days exceded the maximum,Try again");
            }
        }


        public string Name { get;private set; }
        public Guid GroupId { get; private set; }
        public Group Group { get; private set; }
        public Guid? CompanyId { get;private set; }
        public Company? Company { get;private set; }
        public User User { get;private set; }
        public string UserId { get;private set; }
        public PassStatus PassStatus { get; private set; }
        public Activation Activation { get;private set; }
        public Trainee(string name,string userId, Guid groupId, Guid? companyId = null)
        {
            Name = name;
            GroupId = groupId;
            CompanyId = companyId;
            UserId = userId;
            Activation = Activation.Active;
            PassStatus = PassStatus.Passed;
        }
        private Trainee() { }

        public void ChangeActivationStatus(Activation ac)
        {
            Activation = ac;
        }

        public void ChangePassStatus(PassStatus PA)
        {
            PassStatus = PA;
        }
        
    }
}




public enum PassStatus{
    Passed , Failed 
}


public enum Activation
{
    Active , Inactive , Withdrawn
}


