namespace Obligatorisk_Opg1
{
    public class Trophy
    {
        public int ID { get; set; }
        public string Competition { get; set; }
        public int? Year { get; set; }

        public void ValidateCompetition()
        {
            if (Competition == null)
            {
                throw new ArgumentNullException("Competition is null");
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentException("Competition string must be minimum 3 characters long");
            }
        }
        public void ValidateYear()
        {
            if (Year == null)
            {
                throw new ArgumentNullException("Year is null");
            }
            if ((Year < 1970) || (Year > 2024))
            {
                throw new ArgumentOutOfRangeException("Year must be within the range 1970-2024");
            }
        }
        public void ValidateAll()
        {
            ValidateCompetition();
            ValidateYear();
        }
        public override string ToString()
        {
            return $"ID: {ID}\n Competition: {Competition}\n Year: {Year}";
        }
    }
}
