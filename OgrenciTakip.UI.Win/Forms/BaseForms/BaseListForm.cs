﻿using BusinessLayer.Interfaces;
using Common.Enums;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using EntityLayer.Model.Entities.Base;
using OgrenciTakip.UI.Win.Funcitons;
using OgrenciTakip.UI.Win.Show.Interfaces;
using System;
using System.Windows.Forms;

namespace OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected IBaseFormShow FormShow;
        protected KartTuru BaseKartTuru;
        protected internal GridView Tablo;
        protected bool AktifKartlariGoster = true;
        protected internal bool MultiSelect;
        protected internal BaseEntity SelectedEntity;
        protected IBaseBll Bll;
        protected ControlNavigator Navigator;
        protected internal long? SeciliGelecekId;

        public BaseListForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
            {
                button.ItemClick += Button_ItemClick;
            }

            //Table Events
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.KeyDown += Tablo_KeyDown;

            //Form Events
            Shown += BaseListForm_Shown;
        }

        private void BaseListForm_Shown(object sender, EventArgs e)
        {
            Tablo.Focus();
            //ButonGizleGoster();
            //SutunGizleGoster();

            if (IsMdiChild || !SeciliGelecekId.HasValue)
            {
                return;
            }
            else
            {
                Tablo.RowFocus("Id", SeciliGelecekId);
            }
        }

        private void SutunGizleGoster()
        {
            throw new NotImplementedException();
        }

        private void ButonGizleGoster()
        {
            throw new NotImplementedException();
        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Tablo.OptionsSelection.MultiSelect = MultiSelect;
            Navigator.NavigatableControl = Tablo.GridControl;

            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = DefaultCursor;

            // Güncellenecek
        }

        protected virtual void DegiskenleriDoldur() { }

        protected virtual void ShowEditForm(long id)
        {
            var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
        }

        private void EntityDelete()
        {
            throw new NotImplementedException();
        }

        private void SelectEntity()
        {
            if (MultiSelect)
            {
                // Güncellenecek
            }
            else
            {
                SelectedEntity = Tablo.GetRow<BaseEntity>();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual void Listele() { }

        private void FiltreSec()
        {
            throw new NotImplementedException();
        }

        private void Yazdir()
        {
            throw new NotImplementedException();
        }

        private void FormCaptionAyarla()
        {
            throw new NotImplementedException();
        }

        private void IslemTuruSec()
        {
            if (!IsMdiChild)
            {
                // Güncellenecek
                SelectEntity();
            }
            else
            {
                btnDuzelt.PerformClick();
            }
        }
        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnGonder)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnStandartExcelDosyasi)
            {

            }
            else if (e.Item == btnFormatliExcelDosyasi)
            {

            }
            else if (e.Item == btnFormatsizExcelDosyasi)
            {

            }
            else if (e.Item == btnWordDosyasi)
            {

            }
            else if (e.Item == btnPdfDosyasi)
            {

            }
            else if (e.Item == btnTxtDosyasi)
            {

            }
            else if (e.Item == btnYeni)
            {
                //Yetkilendirme Kontrolü
                ShowEditForm(-1);
            }
            else if (e.Item == btnDuzelt)
            {
                ShowEditForm(Tablo.GetRowId());
            }
            else if (e.Item == btnSil)
            {
                //Yetki Kontrolü
                EntityDelete();
            }
            else if (e.Item == btnSec)
            {
                SelectEntity();
            }
            else if (e.Item == btnYenile)
            {
                Listele();
            }
            else if (e.Item == btnFiltrele)
            {
                FiltreSec();
            }
            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm == null)
                {
                    Tablo.ShowCustomization();
                }
                else
                {
                    Tablo.HideCustomization();
                }
            }
            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }
            else if (e.Item == btnCikis)
            {
                Close();
            }
            else if (e.Item == btnAktifPasifKartlar)
            {
                AktifKartlariGoster = !AktifKartlariGoster;
                FormCaptionAyarla();
            }

            Cursor.Current = DefaultCursor;
        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IslemTuruSec();
            Cursor.Current = DefaultCursor;
        }


        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}