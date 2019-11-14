namespace RCNClinicApp
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public partial class ContextDb : DbContext
    {
        public ContextDb()
        {
        }

        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
        }

        public virtual DbSet<tbl_Account> tbl_Account { get; set; }
        public virtual DbSet<tbl_Advertising> tbl_Advertising { get; set; }
        public virtual DbSet<tbl_cash_AllTransaction> tbl_cash_AllTransaction { get; set; }
        public virtual DbSet<tbl_cashrecords> tbl_cashrecords { get; set; }
        public virtual DbSet<tbl_docter> tbl_docter { get; set; }
        public virtual DbSet<tbl_Dual> tbl_Dual { get; set; }
        public virtual DbSet<tbl_GeneralGroups> tbl_GeneralGroups { get; set; }
        public virtual DbSet<tbl_Information> tbl_Information { get; set; }
        public virtual DbSet<tbl_Insure> tbl_Insure { get; set; }
        public virtual DbSet<tbl_InsureAccount> tbl_InsureAccount { get; set; }
        public virtual DbSet<tbl_InsurOrg> tbl_InsurOrg { get; set; }
        public virtual DbSet<tbl_patient> tbl_patient { get; set; }
        public virtual DbSet<tbl_Service> tbl_Service { get; set; }
        public virtual DbSet<tbl_SMS> tbl_SMS { get; set; }
        public virtual DbSet<tbl_Tankhah> tbl_Tankhah { get; set; }
        public virtual DbSet<tbl_Type> tbl_Type { get; set; }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }
        public virtual DbSet<tbl_Users_Role> tbl_Users_Role { get; set; }
        public virtual DbSet<tblPicture> tblPictures { get; set; }
        public virtual DbSet<tblReception> tblReceptions { get; set; }
        public virtual DbSet<tblVisit> tblVisits { get; set; }
        public virtual DbSet<RPTDebtors_Result> RPTDebtors_Result { get; set; }
      
        public virtual DbSet<RptPayment_Result> RptPayment_Result { get; set; }

        public virtual DbSet<Dossier_Result> Dossier_Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
                var connectionString = configuration.GetConnectionString("ContextDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Account>()
                .Property(e => e.NumAccount)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Account>()
                .Property(e => e.NumCard)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Account>()
                .HasMany(e => e.tbl_cash_AllTransaction)
                .WithOne(e => e.tbl_Account)
                .HasForeignKey(e => e.AccountId);

            modelBuilder.Entity<tbl_docter>()
                .HasMany(e => e.tblReceptions)
                .WithOne(e => e.tbl_docter)
                .HasForeignKey(e => e.IdDoctor);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_cash_AllTransaction)
                .WithOne(e => e.tbl_Dual)
                .HasForeignKey(e => e.IdPayType);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_docterCalcType)
                .WithOne(e => e.tbl_DualCalcType)
                .HasForeignKey(e => e.CalculationType);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_docterSpeciality)
                .WithOne(e => e.tbl_DualSpeciality)
                .HasForeignKey(e => e.IdSpecialityDr);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_GeneralGroupTypeWard)
                .WithOne(e => e.tbl_DualTypeWard)
                .HasForeignKey(e => e.IdTypeward);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_GeneralGroupType)
                .WithOne(e => e.tbl_DualType)
                .HasForeignKey(e => e.IdType);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_patient)
                .WithOne(e => e.tbl_Dual)
                .HasForeignKey(e => e.IdSex);
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_Service)
                .WithOne(e => e.tbl_Dual)
                .HasForeignKey(e => e.IdType);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tbl_Users_Role)
                .WithOne(e => e.tbl_Dual)
                .HasForeignKey(e => e.RoleId);
               // .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tblReceptions)
                .WithOne(e => e.tbl_Dual)
                .HasForeignKey(e => e.IdWaiting);

            modelBuilder.Entity<tbl_Dual>()
                .HasMany(e => e.tblVisits)
                .WithOne(e => e.tbl_Dual)
                .HasForeignKey(e => e.IdWaiting);

            modelBuilder.Entity<tbl_GeneralGroups>()
                .HasMany(e => e.tbl_docter)
                .WithOne(e => e.tbl_GeneralGroups)
                .HasForeignKey(e => e.IdGenereal_Group);

            modelBuilder.Entity<tbl_GeneralGroups>()
                .HasMany(e => e.tbl_Service)
                .WithOne(e => e.tbl_GeneralGroups)
                .HasForeignKey(e => e.IdGeneral_Group);

            modelBuilder.Entity<tbl_GeneralGroups>()
                .HasMany(e => e.tbl_Tankhah)
                .WithOne(e => e.tbl_GeneralGroups)
                .HasForeignKey(e => e.IdGeneralGroup);

            modelBuilder.Entity<tbl_GeneralGroups>()
                .HasMany(e => e.tbl_Users)
                .WithOne(e => e.tbl_GeneralGroups)
                .HasForeignKey(e => e.IdGeneralGroup);

            modelBuilder.Entity<tbl_GeneralGroups>()
                .HasMany(e => e.tblReceptions)
                .WithOne(e => e.tbl_GeneralGroups)
                .HasForeignKey(e => e.IdGeneralGroup);

            modelBuilder.Entity<tbl_Insure>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Insure>()
                .HasMany(e => e.tbl_InsureAccount)
                .WithOne(e => e.tbl_Insure)
                .HasForeignKey(e => e.IdInsurence);

            modelBuilder.Entity<tbl_InsurOrg>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InsurOrg>()
                .HasMany(e => e.tbl_Insure)
                .WithOne(e => e.tbl_InsurOrg)
                .HasForeignKey(e => e.IdInsureOrg);

            modelBuilder.Entity<tbl_patient>()
                .HasMany(e => e.tblReceptions)
                .WithOne(e => e.tbl_patient)
                .HasForeignKey(e => e.IdPatient);
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Service>()
                .HasMany(e => e.tbl_Advertising)
                .WithOne(e => e.tbl_Service)
                .HasForeignKey(e => e.IdService);

            modelBuilder.Entity<tbl_Service>()
                .HasMany(e => e.tblReceptions)
                .WithOne(e => e.tbl_Service)
                .HasForeignKey(e => e.IdService);
               // .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Type>()
                .HasMany(e => e.tbl_Dual)
                .WithOne(e => e.tbl_Type)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_cash_AllTransactionEdit)
                .WithOne(e => e.tbl_UserEdit)
                .HasForeignKey(e => e.WhoEdit);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_cash_AllTransactionSave)
                .WithOne(e => e.tbl_UsersSave)
                .HasForeignKey(e => e.WhoSave);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_cashrecordEdit)
                .WithOne(e => e.tbl_UserEdit)
                .HasForeignKey(e => e.WhoEdit);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_cashrecordsSave)
                .WithOne(e => e.tbl_UsersSave)
                .HasForeignKey(e => e.WhoSave);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_InsureAccountEdit)
                .WithOne(e => e.tbl_UserEdit)
                .HasForeignKey(e => e.WhoEdit);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_InsureAccountSave)
                .WithOne(e => e.tbl_UsersSave)
                .HasForeignKey(e => e.WhoSave);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_TankhahEdit)
                .WithOne(e => e.tbl_UserEdit)
                .HasForeignKey(e => e.WhoEdit);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_TankhahSave)
                .WithOne(e => e.tbl_UsersSave)
                .HasForeignKey(e => e.WhoSave);

            modelBuilder.Entity<tbl_Users>()
                .HasMany(e => e.tbl_Users_Role)
                .WithOne(e => e.tbl_Users)
                .HasForeignKey(e => e.UsersId);
               // .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblReception>()
                .HasMany(e => e.tbl_cash_AllTransaction)
                .WithOne(e => e.tblReception)
                .HasForeignKey(e => e.IdReception);

            modelBuilder.Entity<tblReception>()
                .HasMany(e => e.tbl_cashrecords)
                .WithOne(e => e.tblReception)
                .HasForeignKey(e => e.IdReception);

            modelBuilder.Entity<tblReception>()
                .HasMany(e => e.tblVisits)
                .WithOne(e => e.tblReception)
                .HasForeignKey(e => e.IdReception);
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<tblVisit>()
                .HasMany(e => e.tbl_Advertising)
                .WithOne(e => e.tblVisit)
                .HasForeignKey(e => e.IdVisit);
            // .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblVisit>()
                .HasMany(e => e.tbl_SMS)
                .WithOne(e => e.tblVisit)
                .HasForeignKey(e => e.IdVisit);
            //  .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblVisit>()
                .HasMany(e => e.tblPictures)
                .WithOne(e => e.tblVisit)
                .HasForeignKey(e => e.IdVisit);
               // .WillCascadeOnDelete(false);

           // base.OnModelCreating(modelBuilder);
        }
    }
}
