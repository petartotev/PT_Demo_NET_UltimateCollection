﻿namespace Personal.CSharp9.Records
{
    public record RecordChild : RecordPerson
    {
        public string Toy { get; }

        public RecordChild(string firstName, string lastName, string toy) : base(firstName, lastName) => Toy = toy;
    }
}
