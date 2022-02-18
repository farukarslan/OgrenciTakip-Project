using EntityLayer.Model.Entities.Base.Interfaces;
using System;
using System.Linq;

namespace BusinessLayer.Functions
{
    public static class Converts
    {
        //Kaynak ve hedef entity leri alıp kaynak entity nin propertyleri içerisinde gezip istenilenleri hedef entitye atayacağız
        //entity den data transfer object convert işlemi için

        public static TTarget EntityConvert<TTarget>(this IBaseEntity source) //Tüm entityler IBaseEntity den impelemente alacağı için kaynağımızı da bu tipte belirledik
        {
            if (source == null)
            {
                return default(TTarget);
            }
            else
            {
                var hedef = Activator.CreateInstance<TTarget>();
                var kaynakProp = source.GetType().GetProperties();
                var hedefProp = typeof(TTarget).GetProperties(); //Generic tipteki nesnelerin property lerine typeof() kullanılarak ulaşabiliriz.

                foreach (var kp in kaynakProp)
                {
                    var value = kp.GetValue(source);
                    var hp = hedefProp.FirstOrDefault(x => x.Name == kp.Name);
                    if (hp != null)
                    {
                        hp.SetValue(hedef, ReferenceEquals(value, "") ? null : value);
                    }
                }

                return hedef;
            }
        }
    }
}
