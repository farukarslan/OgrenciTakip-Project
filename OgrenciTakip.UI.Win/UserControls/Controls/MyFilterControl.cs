using DevExpress.XtraEditors;
using OgrenciTakip.UI.Win.Interfaces;
using System.ComponentModel;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarAciklama
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true; //Filtreleme/gruplama yaparken onunla alakalı bir icon gözükecek
        }

        public string StatusBarAciklama { get; set; } = "Filtre Metni Giriniz.";
    }
}
