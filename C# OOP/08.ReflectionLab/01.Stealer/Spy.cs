using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
   public class Spy
    {
        public string StealFieldInfo(string name, params string[] data)
        {
            Type type = Type.GetType(name);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            Object classIstance = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {classIstance}");

            foreach (FieldInfo field in fields.Where(x => data.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classIstance)}");
            }

            Console.WriteLine(sb);
            return sb.ToString().TrimEnd();
        }
    }
}
