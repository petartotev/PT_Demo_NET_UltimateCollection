﻿using System;

namespace Personal.CSharp9.Records
{
    public class Program
    {
        static void Main()
        {
            RecordPerson myRec = new RecordPerson("Test", "Testov");

            // CS0200: Property or indexer cannot be assigned to -- it is read only.
            //myRec.FirstName = "No"; 

            Console.WriteLine(myRec.FirstName);
        }
    }
}
