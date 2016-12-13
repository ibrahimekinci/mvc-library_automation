using Mvc_Kutuphane.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Mvc_Kutuphane.DAL
{
    public class db_Context : DbContext
    {
        public db_Context()
            : base("db_Context")
        {
        }
        public DbSet<tbl_rolYetkiListe> rolYetkiListe { get; set; }
        public DbSet<tbl_rolYetki> rolYetki { get; set; }
        public DbSet<tbl_rol> rol { get; set; }
        public DbSet<tbl_kullanici> kullanici { get; set; }
        public DbSet<tbl_adres> adres { get; set; }
        public DbSet<tbl_sehir> sehir { get; set; }
        public DbSet<tbl_ilce> ilce { get; set; }
        public DbSet<tbl_mahalle> mahalle { get; set; }
        public DbSet<tbl_duyuru> duyuru { get; set; }
        public DbSet<tbl_istatislik> istatislik { get; set; }
        public DbSet<tbl_yayinEvi> yayinEvi { get; set; }
        public DbSet<tbl_kitapTur> kitapTur { get; set; }
        public DbSet<tbl_yazar> yazar { get; set; }
        public DbSet<tbl_kitap> kitap { get; set; }
        public DbSet<tbl_kitapBilgi> kitapBilgi { get; set; }
        public DbSet<tbl_kitapHaraket> kitapHaraket { get; set; }
        public DbSet<tbl_kitapSepet> kitapSepet { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}