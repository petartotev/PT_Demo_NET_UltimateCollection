namespace Personal.General.NullableEnable
{
    public class Person
    {
        public string SomePropertyThatShouldNotBeNull { get; set; }

        public Person()
        {
            // "Converting null literal or possible null value to non-nullable type" because of <Nullable>enable</Nullable>.
            //this.SomePropertyThatShouldNotBeNull = null;

            // "Converting null literal or possible null value to non-nullable type" because of <Nullable>enable</Nullable>.
            //this.SomePropertyThatShouldNotBeNull = default;

            this.SomePropertyThatShouldNotBeNull = default!;
        }
    }
}
