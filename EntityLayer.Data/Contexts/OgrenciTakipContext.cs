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
            //Sorguda bir nesneye ait property lerin hepsini �ekmedi�imiz durumlarda yine de di�er istenmeyen propertyleri
            //veritaban�ndan �eker. Bu durumlarda performans kayb� olur. LazyLoading i false yaparak bu durumun �n�ne ge�iyoruz.
            //Sadece istenilen property de�erlerini getirecek.
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //SQL'e g�nderirken database isimlerini �o�ulla�t�rma �zelli�ini devre d��� b�rak�yoruz.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //1-n ili�kili tablolardan bir de�er silinince di�er tabloda ona ba�l� olarak olu�turulan 
            //de�erleri otomatik silmesini devre d��� b�rak�yoruz.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Bir �stteki i�lemin ayn�s� n-n tablolar i�in ge�erli olan� devre d��� b�rakt�k.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }
    }
}