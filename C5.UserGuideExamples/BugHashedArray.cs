// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

// C5 bugs 2007-09-16

// Compile and run with 
//  dotnet clean
//  dotnet build ../C5/C5.csproj
//  dotnet build -p:StartupObject=C5.UserGuideExamples.BugHashedArray
//  dotnet run

using System;

namespace C5.UserGuideExamples
{
    class BugHashedArray
    {
        public static void Main(string[] args)
        {
            var test = new HashedLinkedList<int>();

            for (var i = 0; i < 33; i++)
            {
                test.Add(i);
            }

            // Fails after 7 removals
            for (var i = 0; i < 33; i++)
            {
                Console.WriteLine(i);
                test.Remove(i);
            }

            // Fails after 23 removals
            for (var i = 32; i >= 0; i--)
            {
                Console.WriteLine(i);
                test.Remove(i);
            }
        }
    }
}
