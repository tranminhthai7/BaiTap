using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories.Entities;

public partial class BancaContext : DbContext
{
    public BancaContext()
    {
    }

    public BancaContext(DbContextOptions<BancaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAbout> TbAbouts { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbConfig> TbConfigs { get; set; }

    public virtual DbSet<TbConsignment> TbConsignments { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbFeedback> TbFeedbacks { get; set; }

    public virtual DbSet<TbFooter> TbFooters { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbInvoiceDetail> TbInvoiceDetails { get; set; }

    public virtual DbSet<TbKoi> TbKois { get; set; }

    public virtual DbSet<TbLoyaltyPoint> TbLoyaltyPoints { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderDetail> TbOrderDetails { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }

    public virtual DbSet<TbProductComment> TbProductComments { get; set; }

    public virtual DbSet<TbPromotion> TbPromotions { get; set; }

    public virtual DbSet<TbRating> TbRatings { get; set; }

    public virtual DbSet<TbReport> TbReports { get; set; }

    public virtual DbSet<TbSlide> TbSlides { get; set; }

    public virtual DbSet<TbSupplier> TbSuppliers { get; set; }

    public virtual DbSet<TbTag> TbTags { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3AFG7FJ\\SQLEXPRESS01;Initial Catalog=BANCA;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAbout>(entity =>
        {
            entity.ToTable("tb_About");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.MetaDescriptioins).HasMaxLength(250);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__TbBlog__54379E30436A86BD");

            entity.ToTable("TbBlog");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<TbConfig>(entity =>
        {
            entity.ToTable("tb_Config");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<TbConsignment>(entity =>
        {
            entity.HasKey(e => e.ConsignmentId).HasName("PK__tb_Consi__EAEBA9A3D5FA63E5");

            entity.ToTable("tb_Consignments");

            entity.Property(e => e.ConsignmentId).HasColumnName("Consignment_id");
            entity.Property(e => e.ConsignmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Consignment_date");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.ToTable("tb_Contact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TbFeedback>(entity =>
        {
            entity.ToTable("tb_Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbFooter>(entity =>
        {
            entity.ToTable("tb_Footer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);

            entity.ToTable("tb_Invoice");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedNever()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbInvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId });

            entity.ToTable("tb_InvoiceDetail");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbKoi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Koi");

            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Character).HasColumnType("text");
            entity.Property(e => e.FeedlingAmount).HasColumnName("Feedling_amount");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Health_status");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ScreenRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Screen_rate");
            entity.Property(e => e.Size).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<TbLoyaltyPoint>(entity =>
        {
            entity.HasKey(e => e.LoyaltyPointId).HasName("PK__TbLoyalt__A911B3F4FE5FBFA1");

            entity.ToTable("TbLoyaltyPoint");

            entity.Property(e => e.EarnedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.ToTable("tb_Menu");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Link).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("tb_Orders");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });

            entity.ToTable("tb_OrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Product");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Desiption).HasMaxLength(500);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Hot).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .HasColumnName("image");
            entity.Property(e => e.ListsImage).HasColumnType("xml");
            entity.Property(e => e.MateKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaDescriptioins).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PromotionPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasColumnName("Seo Title");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_ProductCategory");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MateKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaDescriptioins).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasColumnName("Seo Title");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbProductComment>(entity =>
        {
            entity.HasKey(e => e.CommentId);

            entity.ToTable("tb_ProductComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbPromotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__TbPromot__52C42FCF5981C65E");

            entity.ToTable("TbPromotion");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.PromotionName).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbRating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__TbRating__FCCDF87C668B4F29");

            entity.ToTable("TbRating");

            entity.Property(e => e.Feedback).HasMaxLength(255);
            entity.Property(e => e.RatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__TbReport__D5BD4805CE34849F");

            entity.ToTable("TbReport");

            entity.Property(e => e.GeneratedDate).HasColumnType("datetime");
            entity.Property(e => e.ReportName).HasMaxLength(100);
        });

        modelBuilder.Entity<TbSlide>(entity =>
        {
            entity.ToTable("tb_Slide");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.ToTable("tb_Supplier");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTag>(entity =>
        {
            entity.ToTable("tb_Tag");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.ToTable("tb_User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
