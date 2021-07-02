using System;

namespace Personal.OOP.DemoStaticConstructor
{
    public class ClassHavingStaticCtor
    {
        private int propInt;
        private string propString;

        // CS015: 'function' : access modifiers are not allowed on static constructors
        // A static constructor cannot have an access modifier.
        static ClassHavingStaticCtor()
        {
            Console.WriteLine("This is the static ctor calling!");
        }

        public ClassHavingStaticCtor(string objectInstance)
        {
            PropInt = 0;
            PropString = "string";
            Console.WriteLine($"This is the normal ctor called for {objectInstance}!");
        }

        public ClassHavingStaticCtor(int propInt, string propString)
        {
            PropInt = propInt;
            PropString = propString;
            Console.WriteLine("This is the normal ctor calling!");
        }

        public int PropInt
        {
            get
            {
                return this.propInt;
            }
            set
            {
                this.propInt = value;
            }
        }

        public string PropString
        {
            get
            {
                return this.propString;
            }
            set
            {
                this.propString = value;
            }
        }
    }
}
