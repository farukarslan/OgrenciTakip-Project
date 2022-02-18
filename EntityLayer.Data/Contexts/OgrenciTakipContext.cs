using EntityLayer.Data.OgrenciTakipMigration;
using EntityLayer.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityLayer.Data.Contexts
{
    public class OgrenciTakipContext : BaseDbContext<OgrenciTakipContext, Configuration>
    {
        public OgrenciTakipContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public OgrenciTakipContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            //Sorguda bir nesneye ait property lerin hepsini çekmediðimiz durumlarda yine de diðer istenmeyen propertyleri
            //veritabanýndan çeker. Bu durumlarda performans kaybý olur. LazyLoading i false yaparak bu durumun önüne geçiyoruz.
            //Sadece istenilen property deðerlerini getirecek.
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //SQL'e gönderirken database isimlerini çoðullaþtýrma özelliðini devre dýþý býrakýyoruz.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //1-n iliþkili tablolardan bir deðer silinince diðer tabloda ona baðlý olarak oluþturulan 
            //deðerleri otomatik silmesini devre dýþý býrakýyoruz.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Bir üstteki iþlemin aynýsý n-n tablolar için geçerli olaný devre dýþý býraktýk.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }
    }
}