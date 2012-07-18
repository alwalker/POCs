using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CustomConfigSections
{
    public class MultiItemSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public InstanceCollection Instances
        {
            get { return (InstanceCollection)this[""]; }
            set { this[""] = value; }
        }
    }
    public class InstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new InstanceElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((InstanceElement)element).Key;
        }
    }
    public class InstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return (string)base["key"]; }
            set { base["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
    }
}
