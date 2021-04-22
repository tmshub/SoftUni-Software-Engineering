using Stealer;
using System;
using System.Reflection;

namespace Stealer
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
