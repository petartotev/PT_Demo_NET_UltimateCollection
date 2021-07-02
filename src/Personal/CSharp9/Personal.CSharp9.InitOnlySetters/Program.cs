namespace Personal.CSharp9.InitOnlySetters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitCar myCar1 = new InitCar()
            {
                Color = "green",
                CountDoors = 4,
            };

            // CS8852: Init-only property or indexer can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
            //myCar1.CountDoors = 5;
        }
    }
}
