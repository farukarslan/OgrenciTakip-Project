using BusinessLayer.General;
using OgrenciTakip.UI.Win.Forms.BaseForms;
using Common.Enums;
using System;
using EntityLayer.Model.Dto;
using EntityLayer.Model.Entities;
using OgrenciTakip.UI.Win.Funcitons;
using DevExpress.XtraEditors;

namespace OgrenciTakip.UI.Win.Forms.OkulForms
{
    public partial class OkulEditForm : BaseEditForm
    {
        public OkulEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new OkulBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Okul;
            EventsLoad(); //EventsLoad da control içerisindeki elemanlara event veriyoruz. Edit form açılırken de
                          //control ü buradan gönderdiğimiz için gönderdikten sonra Eventleri çağırıyoruz
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new OkulS() : ((OkulBll)Bll).Single(FilterFunctions.Filter<Okul>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert)
            {
                return;
            }

            txtKod.Text = ((OkulBll)Bll).YeniKodVer();
            txtOkulAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (OkulS)OldEntity;

            txtKod.Text = entity.Kod;
            txtOkulAdi.Text = entity.OkulAdi;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Okul
            {
                Id = Id,
                Kod = txtKod.Text,
                OkulAdi = txtOkulAdi.Text,
                IlId = Convert.ToInt64(txtIl.Id),
                IlceId = Convert.ToInt64(txtIlce.Id),
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit))
            {
                return;
            }
            else
            {
                using (var sec = new SelectFunctions())
                {
                    if (sender == txtIl)
                    {
                        sec.Sec(txtIl);
                    }
                    else if (sender == txtIlce)
                    {
                        sec.Sec(txtIlce, txtIl);
                    }
                }
            }
        }
    }
}