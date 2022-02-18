using EntityLayer.Model.Entities;
using EntityLayer.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Model.Dto
{
    [NotMapped] //DTO'daki propertyleri database de tablonun içerisine eklememesi için
    public class OkulS : Okul //Okul'un sonundaki S, single ı ifade ediyor, tek bir veride kullanacağız
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }

    public class OkulL : BaseEntity // OkulL => L : liste
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
