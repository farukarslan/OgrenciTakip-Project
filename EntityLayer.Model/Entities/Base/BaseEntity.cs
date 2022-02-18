﻿using EntityLayer.Model.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Model.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        //Column(Order = 0) ile database de yer alacağı indeksi belirtiyoruz
        //DatabaseGenerated(DatabaseGeneratedOption.None) ile Id alanını otomatik artan şekilde olmaması için ayarladık
        [Column(Order = 0), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Column(Order = 1), Required, StringLength(20)]
        public virtual string Kod { get; set; }
    }
}