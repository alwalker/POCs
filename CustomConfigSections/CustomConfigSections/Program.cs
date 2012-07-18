using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CustomConfigSections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Values from multi item secion:");
            var multiSection = (MultiItemSection)ConfigurationManager.GetSection("MultiItemSection");
            foreach (InstanceElement instance in multiSection.Instances)
            {
                Console.WriteLine(String.Format("key: {0}\tvalue: {1}", instance.Key, instance.Value));
            }
            
            Console.WriteLine("\n\nSingle element values:");
            var singleSection = new PageAppearanceSection();
            Console.WriteLine("RemoteOnly: " + singleSection.RemoteOnly);
            Console.WriteLine("Font Size: " + singleSection.Font.Size);
            Console.WriteLine("Font Name: " + singleSection.Font.Name);

            Console.Read();
        }
    }
}
