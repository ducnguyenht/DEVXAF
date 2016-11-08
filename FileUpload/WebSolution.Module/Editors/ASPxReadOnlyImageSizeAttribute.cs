using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSolution.Module.Web.Editors
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ASPxReadOnlyImageSizeAttribute : Attribute
    {
        public ASPxReadOnlyImageSizeAttribute()
        {
            _Width = 100;
            _Height = 100;
            _WidthProperty = "";
            _HeightProperty = "";
        }
        public ASPxReadOnlyImageSizeAttribute(int width, int height, string widthProperty, string heightProperty)
        {
            _Width = width;
            _Height = height;
            _WidthProperty = widthProperty;
            _HeightProperty = heightProperty;
        }

        private int _Width;
        private int _Height;
        private string _WidthProperty;
        private string _HeightProperty;

        public int Width { get { return _Width; } }
        public int Height { get { return _Height; } }
        public string WidthProperty { get { return _WidthProperty; } }
        public string HeightProperty { get { return _HeightProperty; } }
    }
}
