using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace DiagramDesigner.Tools
{
    public static class ControlUtility
    {
        /// <summary>
        /// 从指定对象复制属性
        /// </summary>
        /// <param name="controlToSet"></param>
        /// <param name="controlToCopy"></param>
        public static void CopyPropertiesFrom(FrameworkElement controlToSet, FrameworkElement controlToCopy)
        {
            foreach (var dependencyValue in GetAllProperties(controlToCopy).Where((item) => !item.ReadOnly).ToDictionary(dependencyProperty => dependencyProperty, controlToCopy.GetValue))
            {
                controlToSet.SetValue(dependencyValue.Key, dependencyValue.Value);
            }
        }

        /// <summary>
        /// 得到所有属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static IList<DependencyProperty> GetAllProperties(DependencyObject obj)
        {
            return (from PropertyDescriptor pd in TypeDescriptor.GetProperties(obj, new Attribute[]
            {
                new PropertyFilterAttribute(PropertyFilterOptions.SetValues)
            })
                    select DependencyPropertyDescriptor.FromProperty(pd)
                    into dpd
                    where dpd != null
                    select dpd.DependencyProperty).ToList();
        }

        public static T CloneControl<T>(T control) where T : Control, new()
        {
            //string xaml = System.Windows.Markup.XamlWriter.Save(control);
            //T rtb2 = System.Windows.Markup.XamlReader.Parse(xaml) as T;
            //return rtb2;
            string rectXaml = XamlWriter.Save(control);
            StringReader stringReader = new StringReader(rectXaml);

            //XmlReader xmlReader = XmlReader.Create(stringReader);
            //T clonedChild = (T)XamlReader.Load(xmlReader);

            var xamlReader = XamlReader.Parse(rectXaml) as T;
            return xamlReader;
        }
    }
}
