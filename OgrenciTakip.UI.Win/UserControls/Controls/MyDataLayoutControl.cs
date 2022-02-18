using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.Windows.Forms;
using System.Drawing;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    public class MyDataLayoutControl : DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false; //Indeks düzenini kendisi belirlemiyecek
        }

        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(this);
        }
    }

    internal class MyLayoutControlImplementor : LayoutControlImplementor
    {
        public MyLayoutControlImplementor(ILayoutControlOwner controlOwner) : base(controlOwner)
        {

        }

        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
        {
            var item = base.CreateLayoutItem(parent);
            item.AppearanceItemCaption.ForeColor = Color.Maroon;
            return item;
        }

        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            var group = base.CreateLayoutGroup(parent);
            group.LayoutMode = LayoutMode.Table;

            group.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute; //sabit
            group.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;
            group.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Percent; //yüzdelik olarak hesapla
            group.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;    //yüzde yüz yap diğer sütuna göre ayarla
            group.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 99 });

            group.OptionsTableLayoutGroup.RowDefinitions.Clear(); //otomatik oluşturulan satırları(2 tane) temizle

            for (int i = 1; i <= 10; i++)
            {
                if (i != 10)
                {
                    group.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                    {
                        SizeType = SizeType.Absolute,
                        Height = 24
                    });
                }
                else
                {
                    group.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                    {
                        SizeType = SizeType.Percent,
                        Height = 100   //sonuncu satır yüzdelik olarak %100 alınacak boyutu değiştikçe otomatik ayarlanacak
                    });
                }
            }

            return group;
        }
    }
}
