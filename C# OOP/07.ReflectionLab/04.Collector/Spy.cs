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

        public string CollectGettersAndSetters(string v)
        {
            Type type = Type.GetType(v);

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (var item in methodInfos.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} will return {item.ReturnType}");
            }

            foreach (var item in methodInfos.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }


        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
           
            StringBuilder sb = new StringBuilder();

            foreach (var item in fields)
            {
                sb.AppendLine($"{item.Name} must be private");
            }
            foreach (var item in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public");
            }
            foreach (var item in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private");
            }


            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {type}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var item in methodInfos)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
