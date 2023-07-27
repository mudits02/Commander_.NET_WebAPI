namespace Commander.DTO
{
    public class CommandCreateDTO
    {
        //We are removing the primary key because that will be created by our databse
        //public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        public string Platform { get; set; }
    }
}