using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NAANCMS.Code.Core.ViewEngineFromConfig
{
    public class ViewLocationSection : ConfigurationSection
    {
        [ConfigurationProperty("locations", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ViewLocationElement),
        AddItemName = "add",
        ClearItemsName = "clear",
        RemoveItemName = "remove")]
        public ViewLocationCollection Locations
        {
            get
            {
                ViewLocationCollection locations =
                    (ViewLocationCollection)base["locations"];
                return locations;
            }
        }
    }

    public class ViewLocationElement : ConfigurationElement
    {
        [ConfigurationProperty("path", IsRequired = true)]
        public String Path
        {
            get
            {
                return (String)this["path"];
            }
            set
            {
                this["path"] = value;
            }
        }

        [ConfigurationProperty("partial", IsRequired = false, DefaultValue = true)]
        public Boolean IsAlsoForPartial
        {
            get
            {
                return (Boolean)this["partial"];
            }
            set
            {
                this["partial"] = value;
            }
        }
    }

    // Define the custom UrlsCollection that contains the 
    // custom UrlsConfigElement elements.
    public class ViewLocationCollection : ConfigurationElementCollection
    {
        public ViewLocationCollection()
        {
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ViewLocationElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ViewLocationElement)element).Path;
        }

        public ViewLocationElement this[int index]
        {
            get
            {
                return (ViewLocationElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public ViewLocationElement this[string Name]
        {
            get
            {
                return (ViewLocationElement)BaseGet(Name);
            }
        }

        public int IndexOf(ViewLocationElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(ViewLocationElement url)
        {
            BaseAdd(url);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ViewLocationElement url)
        {
            if (BaseIndexOf(url) >= 0)
                BaseRemove(url.Path);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}