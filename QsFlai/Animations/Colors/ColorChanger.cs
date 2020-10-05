using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QsFlai.Animations.Colors
{
    class ColorChanger
    {
<<<<<<< HEAD
        public ColorAnimation animation;

        private DependencyProperty property;
        private T @object;

        public ColorChanger(object obj, DependencyProperty property, int speed)
        {
            @object = obj as T;
            this.property = property;

            animation = new ColorAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(speed);

            /*var pro = (obj as T).GetType().GetProperty(property.ToString());
            pro.SetValue((obj as T), Brushes.Red);
            //control.Background = Brushes.Red;*/
        }

        public void changeColor(Color color)
        {
            // Попробовать перписать класс Animation в abstract для 
            // переиспользовния его

            /*///
            var pro = animation.GetType().GetProperty((DoubleAnimation.FromProperty).Name);
            pro.SetValue(animation, (double)size);
            ///*/

            AbstractObject o = new AbstractObject(animation);
            AbstractObject obj = new AbstractObject(@object);
            o.set("To",color);
            //obj.set("BeginAnimation", new object []{property,animation});// animation.BeginAnimation(property,animation);
            o.execute("BeginAnimation", new object[] { property, animation });
        }
    }

    public class AbstractObject
    {
        public object obj;

        public AbstractObject(object obj)
        {
            this.obj = obj;
        }

        public void execute(string method, object[] arguments)
        {
            GetMethod(method).Invoke(obj,arguments);
        }

        private MethodInfo GetMethod(string method)
        {
            return (MethodInfo) obj.GetType().GetMethods().Where(x=>x.Name == method).LastOrDefault();
        }

        public object get(DependencyProperty property)
        {
            return get(property.ToString());
        }
        public object get(String property)
        {
            return GetProperty(property).GetValue(obj);
        }

        public void set(DependencyProperty property, object value)
        {
            set(property.ToString(),value);
        }
        public void set(string property, object value)
        {
            GetProperty(property).SetValue(obj, value);
        }

        private PropertyInfo GetProperty(String property)
        {
            return obj.GetType().GetProperty(property);
        }
=======
>>>>>>> master
    }
}
