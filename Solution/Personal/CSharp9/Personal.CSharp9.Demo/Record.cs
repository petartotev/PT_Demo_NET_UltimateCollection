namespace Personal.CSharp9.Demo
{
    public record Record
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Record(string first, string last) => (FirstName, LastName) = (first, last);
    }
}
