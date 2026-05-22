using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class QiraaConfiguration : IEntityTypeConfiguration<Qiraa>
{
    public void Configure(EntityTypeBuilder<Qiraa> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
        builder.HasIndex(x => x.Slug).IsUnique();

        builder.Property(x => x.NameArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.NameEnglish).HasMaxLength(200);
        builder.Property(x => x.RawiArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.ImamArabic).HasMaxLength(400);
        builder.Property(x => x.DescriptionArabic).HasMaxLength(1000);

        builder.HasMany(x => x.AudioTracks)
            .WithOne(x => x.Qiraa)
            .HasForeignKey(x => x.QiraaId);

        builder.HasData(
    new Qiraa 
    {
        Id = 1,
        Slug = "hafs-an-asim",
        NameArabic = "حفص عن عاصم",
        NameEnglish = "Hafs an Asim",
        RawiArabic = "حفص",
        ImamArabic = "عاصم",
        DisplayOrder = 1,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 2,
        Slug = "shubah-an-asim",
        NameArabic = "شعبة عن عاصم",
        NameEnglish = "Shu'bah an Asim",
        RawiArabic = "شعبة",
        ImamArabic = "عاصم",
        DisplayOrder = 2,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 3,
        Slug = "warsh-an-nafi",
        NameArabic = "ورش عن نافع",
        NameEnglish = "Warsh an Nafi",
        RawiArabic = "ورش",
        ImamArabic = "نافع",
        DisplayOrder = 3,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 4,
        Slug = "qalun-an-nafi",
        NameArabic = "قالون عن نافع",
        NameEnglish = "Qalun an Nafi",
        RawiArabic = "قالون",
        ImamArabic = "نافع",
        DisplayOrder = 4,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 5,
        Slug = "al-bazzi-an-ibn-kathir",
        NameArabic = "البزي عن ابن كثير",
        NameEnglish = "Al-Bazzi an Ibn Kathir",
        RawiArabic = "البزي",
        ImamArabic = "ابن كثير",
        DisplayOrder = 5,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 6,
        Slug = "qunbul-an-ibn-kathir",
        NameArabic = "قنبل عن ابن كثير",
        NameEnglish = "Qunbul an Ibn Kathir",
        RawiArabic = "قنبل",
        ImamArabic = "ابن كثير",
        DisplayOrder = 6,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 7,
        Slug = "al-duri-an-abu-amr",
        NameArabic = "الدوري عن أبي عمرو",
        NameEnglish = "Al-Duri an Abu Amr",
        RawiArabic = "الدوري",
        ImamArabic = "أبو عمرو",
        DisplayOrder = 7,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 8,
        Slug = "as-susi-an-abu-amr",
        NameArabic = "السوسي عن أبي عمرو",
        NameEnglish = "As-Susi an Abu Amr",
        RawiArabic = "السوسي",
        ImamArabic = "أبو عمرو",
        DisplayOrder = 8,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 9,
        Slug = "hisham-an-ibn-amir",
        NameArabic = "هشام عن ابن عامر",
        NameEnglish = "Hisham an Ibn Amir",
        RawiArabic = "هشام",
        ImamArabic = "ابن عامر",
        DisplayOrder = 9,
        IsPublished = true
    },
    new Qiraa 
    {
        Id = 10,
        Slug = "ibn-dhakwan-an-ibn-amir",
        NameArabic = "ابن ذكوان عن ابن عامر",
        NameEnglish = "Ibn Dhakwan an Ibn Amir",
        RawiArabic = "ابن ذكوان",
        ImamArabic = "ابن عامر",
        DisplayOrder = 10,
        IsPublished = true
    }
);

    }
}

