namespace Personal.General.NullableEnable
{
    class Program
    {
        static void Main()
        {
            // See .csproj file - it uses C# Nullable References:
            // <Nullable>enable</Nullable>
            // <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
            // https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references

            // Does not compile - warning is treated as error "Converting null literal or possible null value to non-nullable type".
            //Person myPerson = null;
            //myPerson.Equals(null);
        }
    }
}
