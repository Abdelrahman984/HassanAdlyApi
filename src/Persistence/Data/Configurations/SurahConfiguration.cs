using HassanAdly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HassanAdly.Persistence.Data.Configurations;

public sealed class SurahConfiguration : IEntityTypeConfiguration<Surah>
{
    public void Configure(EntityTypeBuilder<Surah> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.NameArabic).HasMaxLength(400).IsRequired();
        builder.Property(x => x.NameTransliteration).HasMaxLength(200).IsRequired();
        builder.Property(x => x.NameEnglish).HasMaxLength(200);
        builder.Property(x => x.SeoTitleArabic).HasMaxLength(400);
        builder.Property(x => x.SeoDescriptionArabic).HasMaxLength(1000);
        builder.Property(x => x.SeoTitleEnglish).HasMaxLength(400);
        builder.Property(x => x.SeoDescriptionEnglish).HasMaxLength(1000);
        builder.Property(x => x.SearchNormalizedArabic).HasMaxLength(600).IsRequired();

        builder.HasMany(x => x.AudioTracks)
            .WithOne(x => x.Surah)
            .HasForeignKey(x => x.SurahId);

        builder.HasMany(x => x.Ayat)
            .WithOne(x => x.Surah)
            .HasForeignKey(x => x.SurahId);

        builder.HasData(
    new Surah 
    {
        Id = 1,
        NameArabic = "سُورَةُ ٱلْفَاتِحَةِ",
        NameTransliteration = "Al-Faatiha",
        NameEnglish = "The Opening",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 7,
        DisplayOrder = 1,
        SearchNormalizedArabic = "سورة ٱلفاتحة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 2,
        NameArabic = "سُورَةُ البَقَرَةِ",
        NameTransliteration = "Al-Baqara",
        NameEnglish = "The Cow",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 286,
        DisplayOrder = 2,
        SearchNormalizedArabic = "سورة البقرة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 3,
        NameArabic = "سُورَةُ آلِ عِمۡرَانَ",
        NameTransliteration = "Aal-i-Imraan",
        NameEnglish = "The Family of Imraan",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 200,
        DisplayOrder = 3,
        SearchNormalizedArabic = "سورة ال عمۡران",
        IsPublished = true
    },
    new Surah 
    {
        Id = 4,
        NameArabic = "سُورَةُ النِّسَاءِ",
        NameTransliteration = "An-Nisaa",
        NameEnglish = "The Women",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 176,
        DisplayOrder = 4,
        SearchNormalizedArabic = "سورة النساء",
        IsPublished = true
    },
    new Surah 
    {
        Id = 5,
        NameArabic = "سُورَةُ المَائـِدَةِ",
        NameTransliteration = "Al-Maaida",
        NameEnglish = "The Table",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 120,
        DisplayOrder = 5,
        SearchNormalizedArabic = "سورة المائـدة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 6,
        NameArabic = "سُورَةُ الأَنۡعَامِ",
        NameTransliteration = "Al-An'aam",
        NameEnglish = "The Cattle",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 165,
        DisplayOrder = 6,
        SearchNormalizedArabic = "سورة الأنۡعام",
        IsPublished = true
    },
    new Surah 
    {
        Id = 7,
        NameArabic = "سُورَةُ الأَعۡرَافِ",
        NameTransliteration = "Al-A'raaf",
        NameEnglish = "The Heights",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 206,
        DisplayOrder = 7,
        SearchNormalizedArabic = "سورة الأعۡراف",
        IsPublished = true
    },
    new Surah 
    {
        Id = 8,
        NameArabic = "سُورَةُ الأَنفَالِ",
        NameTransliteration = "Al-Anfaal",
        NameEnglish = "The Spoils of War",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 75,
        DisplayOrder = 8,
        SearchNormalizedArabic = "سورة الأنفال",
        IsPublished = true
    },
    new Surah 
    {
        Id = 9,
        NameArabic = "سُورَةُ التَّوۡبَةِ",
        NameTransliteration = "At-Tawba",
        NameEnglish = "The Repentance",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 129,
        DisplayOrder = 9,
        SearchNormalizedArabic = "سورة التوۡبة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 10,
        NameArabic = "سُورَةُ يُونُسَ",
        NameTransliteration = "Yunus",
        NameEnglish = "Jonas",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 109,
        DisplayOrder = 10,
        SearchNormalizedArabic = "سورة يونس",
        IsPublished = true
    },
    new Surah 
    {
        Id = 11,
        NameArabic = "سُورَةُ هُودٍ",
        NameTransliteration = "Hud",
        NameEnglish = "Hud",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 123,
        DisplayOrder = 11,
        SearchNormalizedArabic = "سورة هود",
        IsPublished = true
    },
    new Surah 
    {
        Id = 12,
        NameArabic = "سُورَةُ يُوسُفَ",
        NameTransliteration = "Yusuf",
        NameEnglish = "Joseph",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 111,
        DisplayOrder = 12,
        SearchNormalizedArabic = "سورة يوسف",
        IsPublished = true
    },
    new Surah 
    {
        Id = 13,
        NameArabic = "سُورَةُ الرَّعۡدِ",
        NameTransliteration = "Ar-Ra'd",
        NameEnglish = "The Thunder",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 43,
        DisplayOrder = 13,
        SearchNormalizedArabic = "سورة الرعۡد",
        IsPublished = true
    },
    new Surah 
    {
        Id = 14,
        NameArabic = "سُورَةُ إِبۡرَاهِيمَ",
        NameTransliteration = "Ibrahim",
        NameEnglish = "Abraham",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 52,
        DisplayOrder = 14,
        SearchNormalizedArabic = "سورة إبۡراهيم",
        IsPublished = true
    },
    new Surah 
    {
        Id = 15,
        NameArabic = "سُورَةُ الحِجۡرِ",
        NameTransliteration = "Al-Hijr",
        NameEnglish = "The Rock",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 99,
        DisplayOrder = 15,
        SearchNormalizedArabic = "سورة الحجۡر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 16,
        NameArabic = "سُورَةُ النَّحۡلِ",
        NameTransliteration = "An-Nahl",
        NameEnglish = "The Bee",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 128,
        DisplayOrder = 16,
        SearchNormalizedArabic = "سورة النحۡل",
        IsPublished = true
    },
    new Surah 
    {
        Id = 17,
        NameArabic = "سُورَةُ الإِسۡرَاءِ",
        NameTransliteration = "Al-Israa",
        NameEnglish = "The Night Journey",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 111,
        DisplayOrder = 17,
        SearchNormalizedArabic = "سورة الإسۡراء",
        IsPublished = true
    },
    new Surah 
    {
        Id = 18,
        NameArabic = "سُورَةُ الكَهۡفِ",
        NameTransliteration = "Al-Kahf",
        NameEnglish = "The Cave",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 110,
        DisplayOrder = 18,
        SearchNormalizedArabic = "سورة الكهۡف",
        IsPublished = true
    },
    new Surah 
    {
        Id = 19,
        NameArabic = "سُورَةُ مَرۡيَمَ",
        NameTransliteration = "Maryam",
        NameEnglish = "Mary",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 98,
        DisplayOrder = 19,
        SearchNormalizedArabic = "سورة مرۡيم",
        IsPublished = true
    },
    new Surah 
    {
        Id = 20,
        NameArabic = "سُورَةُ طه",
        NameTransliteration = "Taa-Haa",
        NameEnglish = "Taa-Haa",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 135,
        DisplayOrder = 20,
        SearchNormalizedArabic = "سورة طه",
        IsPublished = true
    },
    new Surah 
    {
        Id = 21,
        NameArabic = "سُورَةُ الأَنبِيَاءِ",
        NameTransliteration = "Al-Anbiyaa",
        NameEnglish = "The Prophets",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 112,
        DisplayOrder = 21,
        SearchNormalizedArabic = "سورة الأنبياء",
        IsPublished = true
    },
    new Surah 
    {
        Id = 22,
        NameArabic = "سُورَةُ الحَجِّ",
        NameTransliteration = "Al-Hajj",
        NameEnglish = "The Pilgrimage",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 78,
        DisplayOrder = 22,
        SearchNormalizedArabic = "سورة الحج",
        IsPublished = true
    },
    new Surah 
    {
        Id = 23,
        NameArabic = "سُورَةُ المُؤۡمِنُونَ",
        NameTransliteration = "Al-Muminoon",
        NameEnglish = "The Believers",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 118,
        DisplayOrder = 23,
        SearchNormalizedArabic = "سورة المؤۡمنون",
        IsPublished = true
    },
    new Surah 
    {
        Id = 24,
        NameArabic = "سُورَةُ النُّورِ",
        NameTransliteration = "An-Noor",
        NameEnglish = "The Light",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 64,
        DisplayOrder = 24,
        SearchNormalizedArabic = "سورة النور",
        IsPublished = true
    },
    new Surah 
    {
        Id = 25,
        NameArabic = "سُورَةُ الفُرۡقَانِ",
        NameTransliteration = "Al-Furqaan",
        NameEnglish = "The Criterion",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 77,
        DisplayOrder = 25,
        SearchNormalizedArabic = "سورة الفرۡقان",
        IsPublished = true
    },
    new Surah 
    {
        Id = 26,
        NameArabic = "سُورَةُ الشُّعَرَاءِ",
        NameTransliteration = "Ash-Shu'araa",
        NameEnglish = "The Poets",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 227,
        DisplayOrder = 26,
        SearchNormalizedArabic = "سورة الشعراء",
        IsPublished = true
    },
    new Surah 
    {
        Id = 27,
        NameArabic = "سُورَةُ النَّمۡلِ",
        NameTransliteration = "An-Naml",
        NameEnglish = "The Ant",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 93,
        DisplayOrder = 27,
        SearchNormalizedArabic = "سورة النمۡل",
        IsPublished = true
    },
    new Surah 
    {
        Id = 28,
        NameArabic = "سُورَةُ القَصَصِ",
        NameTransliteration = "Al-Qasas",
        NameEnglish = "The Stories",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 88,
        DisplayOrder = 28,
        SearchNormalizedArabic = "سورة القصص",
        IsPublished = true
    },
    new Surah 
    {
        Id = 29,
        NameArabic = "سُورَةُ العَنكَبُوتِ",
        NameTransliteration = "Al-Ankaboot",
        NameEnglish = "The Spider",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 69,
        DisplayOrder = 29,
        SearchNormalizedArabic = "سورة العنكبوت",
        IsPublished = true
    },
    new Surah 
    {
        Id = 30,
        NameArabic = "سُورَةُ الرُّومِ",
        NameTransliteration = "Ar-Room",
        NameEnglish = "The Romans",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 60,
        DisplayOrder = 30,
        SearchNormalizedArabic = "سورة الروم",
        IsPublished = true
    },
    new Surah 
    {
        Id = 31,
        NameArabic = "سُورَةُ لُقۡمَانَ",
        NameTransliteration = "Luqman",
        NameEnglish = "Luqman",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 34,
        DisplayOrder = 31,
        SearchNormalizedArabic = "سورة لقۡمان",
        IsPublished = true
    },
    new Surah 
    {
        Id = 32,
        NameArabic = "سُورَةُ السَّجۡدَةِ",
        NameTransliteration = "As-Sajda",
        NameEnglish = "The Prostration",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 30,
        DisplayOrder = 32,
        SearchNormalizedArabic = "سورة السجۡدة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 33,
        NameArabic = "سُورَةُ الأَحۡزَابِ",
        NameTransliteration = "Al-Ahzaab",
        NameEnglish = "The Clans",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 73,
        DisplayOrder = 33,
        SearchNormalizedArabic = "سورة الأحۡزاب",
        IsPublished = true
    },
    new Surah 
    {
        Id = 34,
        NameArabic = "سُورَةُ سَبَإٍ",
        NameTransliteration = "Saba",
        NameEnglish = "Sheba",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 54,
        DisplayOrder = 34,
        SearchNormalizedArabic = "سورة سبإ",
        IsPublished = true
    },
    new Surah 
    {
        Id = 35,
        NameArabic = "سُورَةُ فَاطِرٍ",
        NameTransliteration = "Faatir",
        NameEnglish = "The Originator",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 45,
        DisplayOrder = 35,
        SearchNormalizedArabic = "سورة فاطر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 36,
        NameArabic = "سُورَةُ يسٓ",
        NameTransliteration = "Yaseen",
        NameEnglish = "Yaseen",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 83,
        DisplayOrder = 36,
        SearchNormalizedArabic = "سورة يس",
        IsPublished = true
    },
    new Surah 
    {
        Id = 37,
        NameArabic = "سُورَةُ الصَّافَّاتِ",
        NameTransliteration = "As-Saaffaat",
        NameEnglish = "Those drawn up in Ranks",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 182,
        DisplayOrder = 37,
        SearchNormalizedArabic = "سورة الصافات",
        IsPublished = true
    },
    new Surah 
    {
        Id = 38,
        NameArabic = "سُورَةُ صٓ",
        NameTransliteration = "Saad",
        NameEnglish = "The letter Saad",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 88,
        DisplayOrder = 38,
        SearchNormalizedArabic = "سورة ص",
        IsPublished = true
    },
    new Surah 
    {
        Id = 39,
        NameArabic = "سُورَةُ الزُّمَرِ",
        NameTransliteration = "Az-Zumar",
        NameEnglish = "The Groups",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 75,
        DisplayOrder = 39,
        SearchNormalizedArabic = "سورة الزمر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 40,
        NameArabic = "سُورَةُ غَافِرٍ",
        NameTransliteration = "Ghafir",
        NameEnglish = "The Forgiver",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 85,
        DisplayOrder = 40,
        SearchNormalizedArabic = "سورة غافر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 41,
        NameArabic = "سُورَةُ فُصِّلَتۡ",
        NameTransliteration = "Fussilat",
        NameEnglish = "Explained in detail",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 54,
        DisplayOrder = 41,
        SearchNormalizedArabic = "سورة فصلتۡ",
        IsPublished = true
    },
    new Surah 
    {
        Id = 42,
        NameArabic = "سُورَةُ الشُّورَىٰ",
        NameTransliteration = "Ash-Shura",
        NameEnglish = "Consultation",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 53,
        DisplayOrder = 42,
        SearchNormalizedArabic = "سورة الشورىٰ",
        IsPublished = true
    },
    new Surah 
    {
        Id = 43,
        NameArabic = "سُورَةُ الزُّخۡرُفِ",
        NameTransliteration = "Az-Zukhruf",
        NameEnglish = "Ornaments of gold",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 89,
        DisplayOrder = 43,
        SearchNormalizedArabic = "سورة الزخۡرف",
        IsPublished = true
    },
    new Surah 
    {
        Id = 44,
        NameArabic = "سُورَةُ الدُّخَانِ",
        NameTransliteration = "Ad-Dukhaan",
        NameEnglish = "The Smoke",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 59,
        DisplayOrder = 44,
        SearchNormalizedArabic = "سورة الدخان",
        IsPublished = true
    },
    new Surah 
    {
        Id = 45,
        NameArabic = "سُورَةُ الجَاثِيَةِ",
        NameTransliteration = "Al-Jaathiya",
        NameEnglish = "Crouching",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 37,
        DisplayOrder = 45,
        SearchNormalizedArabic = "سورة الجاثية",
        IsPublished = true
    },
    new Surah 
    {
        Id = 46,
        NameArabic = "سُورَةُ الأَحۡقَافِ",
        NameTransliteration = "Al-Ahqaf",
        NameEnglish = "The Dunes",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 35,
        DisplayOrder = 46,
        SearchNormalizedArabic = "سورة الأحۡقاف",
        IsPublished = true
    },
    new Surah 
    {
        Id = 47,
        NameArabic = "سُورَةُ مُحَمَّدٍ",
        NameTransliteration = "Muhammad",
        NameEnglish = "Muhammad",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 38,
        DisplayOrder = 47,
        SearchNormalizedArabic = "سورة محمد",
        IsPublished = true
    },
    new Surah 
    {
        Id = 48,
        NameArabic = "سُورَةُ الفَتۡحِ",
        NameTransliteration = "Al-Fath",
        NameEnglish = "The Victory",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 29,
        DisplayOrder = 48,
        SearchNormalizedArabic = "سورة الفتۡح",
        IsPublished = true
    },
    new Surah 
    {
        Id = 49,
        NameArabic = "سُورَةُ الحُجُرَاتِ",
        NameTransliteration = "Al-Hujuraat",
        NameEnglish = "The Inner Apartments",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 18,
        DisplayOrder = 49,
        SearchNormalizedArabic = "سورة الحجرات",
        IsPublished = true
    },
    new Surah 
    {
        Id = 50,
        NameArabic = "سُورَةُ قٓ",
        NameTransliteration = "Qaaf",
        NameEnglish = "The letter Qaaf",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 45,
        DisplayOrder = 50,
        SearchNormalizedArabic = "سورة ق",
        IsPublished = true
    },
    new Surah 
    {
        Id = 51,
        NameArabic = "سُورَةُ الذَّارِيَاتِ",
        NameTransliteration = "Adh-Dhaariyat",
        NameEnglish = "The Winnowing Winds",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 60,
        DisplayOrder = 51,
        SearchNormalizedArabic = "سورة الذاريات",
        IsPublished = true
    },
    new Surah 
    {
        Id = 52,
        NameArabic = "سُورَةُ الطُّورِ",
        NameTransliteration = "At-Tur",
        NameEnglish = "The Mount",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 49,
        DisplayOrder = 52,
        SearchNormalizedArabic = "سورة الطور",
        IsPublished = true
    },
    new Surah 
    {
        Id = 53,
        NameArabic = "سُورَةُ النَّجۡمِ",
        NameTransliteration = "An-Najm",
        NameEnglish = "The Star",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 62,
        DisplayOrder = 53,
        SearchNormalizedArabic = "سورة النجۡم",
        IsPublished = true
    },
    new Surah 
    {
        Id = 54,
        NameArabic = "سُورَةُ القَمَرِ",
        NameTransliteration = "Al-Qamar",
        NameEnglish = "The Moon",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 55,
        DisplayOrder = 54,
        SearchNormalizedArabic = "سورة القمر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 55,
        NameArabic = "سُورَةُ الرَّحۡمَٰن",
        NameTransliteration = "Ar-Rahmaan",
        NameEnglish = "The Beneficent",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 78,
        DisplayOrder = 55,
        SearchNormalizedArabic = "سورة الرحۡمٰن",
        IsPublished = true
    },
    new Surah 
    {
        Id = 56,
        NameArabic = "سُورَةُ الوَاقِعَةِ",
        NameTransliteration = "Al-Waaqia",
        NameEnglish = "The Inevitable",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 96,
        DisplayOrder = 56,
        SearchNormalizedArabic = "سورة الواقعة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 57,
        NameArabic = "سُورَةُ الحَدِيدِ",
        NameTransliteration = "Al-Hadid",
        NameEnglish = "The Iron",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 29,
        DisplayOrder = 57,
        SearchNormalizedArabic = "سورة الحديد",
        IsPublished = true
    },
    new Surah 
    {
        Id = 58,
        NameArabic = "سُورَةُ المُجَادلَةِ",
        NameTransliteration = "Al-Mujaadila",
        NameEnglish = "The Pleading Woman",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 22,
        DisplayOrder = 58,
        SearchNormalizedArabic = "سورة المجادلة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 59,
        NameArabic = "سُورَةُ الحَشۡرِ",
        NameTransliteration = "Al-Hashr",
        NameEnglish = "The Exile",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 24,
        DisplayOrder = 59,
        SearchNormalizedArabic = "سورة الحشۡر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 60,
        NameArabic = "سُورَةُ المُمۡتَحنَةِ",
        NameTransliteration = "Al-Mumtahana",
        NameEnglish = "She that is to be examined",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 13,
        DisplayOrder = 60,
        SearchNormalizedArabic = "سورة الممۡتحنة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 61,
        NameArabic = "سُورَةُ الصَّفِّ",
        NameTransliteration = "As-Saff",
        NameEnglish = "The Ranks",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 14,
        DisplayOrder = 61,
        SearchNormalizedArabic = "سورة الصف",
        IsPublished = true
    },
    new Surah 
    {
        Id = 62,
        NameArabic = "سُورَةُ الجُمُعَةِ",
        NameTransliteration = "Al-Jumu'a",
        NameEnglish = "Friday",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 11,
        DisplayOrder = 62,
        SearchNormalizedArabic = "سورة الجمعة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 63,
        NameArabic = "سُورَةُ المُنَافِقُونَ",
        NameTransliteration = "Al-Munaafiqoon",
        NameEnglish = "The Hypocrites",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 11,
        DisplayOrder = 63,
        SearchNormalizedArabic = "سورة المنافقون",
        IsPublished = true
    },
    new Surah 
    {
        Id = 64,
        NameArabic = "سُورَةُ التَّغَابُنِ",
        NameTransliteration = "At-Taghaabun",
        NameEnglish = "Mutual Disillusion",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 18,
        DisplayOrder = 64,
        SearchNormalizedArabic = "سورة التغابن",
        IsPublished = true
    },
    new Surah 
    {
        Id = 65,
        NameArabic = "سُورَةُ الطَّلَاقِ",
        NameTransliteration = "At-Talaaq",
        NameEnglish = "Divorce",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 12,
        DisplayOrder = 65,
        SearchNormalizedArabic = "سورة الطلاق",
        IsPublished = true
    },
    new Surah 
    {
        Id = 66,
        NameArabic = "سُورَةُ التَّحۡرِيمِ",
        NameTransliteration = "At-Tahrim",
        NameEnglish = "The Prohibition",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 12,
        DisplayOrder = 66,
        SearchNormalizedArabic = "سورة التحۡريم",
        IsPublished = true
    },
    new Surah 
    {
        Id = 67,
        NameArabic = "سُورَةُ المُلۡكِ",
        NameTransliteration = "Al-Mulk",
        NameEnglish = "The Sovereignty",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 30,
        DisplayOrder = 67,
        SearchNormalizedArabic = "سورة الملۡك",
        IsPublished = true
    },
    new Surah 
    {
        Id = 68,
        NameArabic = "سُورَةُ القَلَمِ",
        NameTransliteration = "Al-Qalam",
        NameEnglish = "The Pen",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 52,
        DisplayOrder = 68,
        SearchNormalizedArabic = "سورة القلم",
        IsPublished = true
    },
    new Surah 
    {
        Id = 69,
        NameArabic = "سُورَةُ الحَاقَّةِ",
        NameTransliteration = "Al-Haaqqa",
        NameEnglish = "The Reality",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 52,
        DisplayOrder = 69,
        SearchNormalizedArabic = "سورة الحاقة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 70,
        NameArabic = "سُورَةُ المَعَارِجِ",
        NameTransliteration = "Al-Ma'aarij",
        NameEnglish = "The Ascending Stairways",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 44,
        DisplayOrder = 70,
        SearchNormalizedArabic = "سورة المعارج",
        IsPublished = true
    },
    new Surah 
    {
        Id = 71,
        NameArabic = "سُورَةُ نُوحٍ",
        NameTransliteration = "Nooh",
        NameEnglish = "Noah",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 28,
        DisplayOrder = 71,
        SearchNormalizedArabic = "سورة نوح",
        IsPublished = true
    },
    new Surah 
    {
        Id = 72,
        NameArabic = "سُورَةُ الجِنِّ",
        NameTransliteration = "Al-Jinn",
        NameEnglish = "The Jinn",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 28,
        DisplayOrder = 72,
        SearchNormalizedArabic = "سورة الجن",
        IsPublished = true
    },
    new Surah 
    {
        Id = 73,
        NameArabic = "سُورَةُ المُزَّمِّلِ",
        NameTransliteration = "Al-Muzzammil",
        NameEnglish = "The Enshrouded One",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 20,
        DisplayOrder = 73,
        SearchNormalizedArabic = "سورة المزمل",
        IsPublished = true
    },
    new Surah 
    {
        Id = 74,
        NameArabic = "سُورَةُ المُدَّثِّرِ",
        NameTransliteration = "Al-Muddaththir",
        NameEnglish = "The Cloaked One",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 56,
        DisplayOrder = 74,
        SearchNormalizedArabic = "سورة المدثر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 75,
        NameArabic = "سُورَةُ القِيَامَةِ",
        NameTransliteration = "Al-Qiyaama",
        NameEnglish = "The Resurrection",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 40,
        DisplayOrder = 75,
        SearchNormalizedArabic = "سورة القيامة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 76,
        NameArabic = "سُورَةُ الإِنسَانِ",
        NameTransliteration = "Al-Insaan",
        NameEnglish = "Man",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 31,
        DisplayOrder = 76,
        SearchNormalizedArabic = "سورة الإنسان",
        IsPublished = true
    },
    new Surah 
    {
        Id = 77,
        NameArabic = "سُورَةُ المُرۡسَلَاتِ",
        NameTransliteration = "Al-Mursalaat",
        NameEnglish = "The Emissaries",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 50,
        DisplayOrder = 77,
        SearchNormalizedArabic = "سورة المرۡسلات",
        IsPublished = true
    },
    new Surah 
    {
        Id = 78,
        NameArabic = "سُورَةُ النَّبَإِ",
        NameTransliteration = "An-Naba",
        NameEnglish = "The Announcement",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 40,
        DisplayOrder = 78,
        SearchNormalizedArabic = "سورة النبإ",
        IsPublished = true
    },
    new Surah 
    {
        Id = 79,
        NameArabic = "سُورَةُ النَّازِعَاتِ",
        NameTransliteration = "An-Naazi'aat",
        NameEnglish = "Those who drag forth",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 46,
        DisplayOrder = 79,
        SearchNormalizedArabic = "سورة النازعات",
        IsPublished = true
    },
    new Surah 
    {
        Id = 80,
        NameArabic = "سُورَةُ عَبَسَ",
        NameTransliteration = "Abasa",
        NameEnglish = "He frowned",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 42,
        DisplayOrder = 80,
        SearchNormalizedArabic = "سورة عبس",
        IsPublished = true
    },
    new Surah 
    {
        Id = 81,
        NameArabic = "سُورَةُ التَّكۡوِيرِ",
        NameTransliteration = "At-Takwir",
        NameEnglish = "The Overthrowing",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 29,
        DisplayOrder = 81,
        SearchNormalizedArabic = "سورة التكۡوير",
        IsPublished = true
    },
    new Surah 
    {
        Id = 82,
        NameArabic = "سُورَةُ الانفِطَارِ",
        NameTransliteration = "Al-Infitaar",
        NameEnglish = "The Cleaving",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 19,
        DisplayOrder = 82,
        SearchNormalizedArabic = "سورة الانفطار",
        IsPublished = true
    },
    new Surah 
    {
        Id = 83,
        NameArabic = "سُورَةُ المُطَفِّفِينَ",
        NameTransliteration = "Al-Mutaffifin",
        NameEnglish = "Defrauding",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 36,
        DisplayOrder = 83,
        SearchNormalizedArabic = "سورة المطففين",
        IsPublished = true
    },
    new Surah 
    {
        Id = 84,
        NameArabic = "سُورَةُ الانشِقَاقِ",
        NameTransliteration = "Al-Inshiqaaq",
        NameEnglish = "The Splitting Open",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 25,
        DisplayOrder = 84,
        SearchNormalizedArabic = "سورة الانشقاق",
        IsPublished = true
    },
    new Surah 
    {
        Id = 85,
        NameArabic = "سُورَةُ البُرُوجِ",
        NameTransliteration = "Al-Burooj",
        NameEnglish = "The Constellations",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 22,
        DisplayOrder = 85,
        SearchNormalizedArabic = "سورة البروج",
        IsPublished = true
    },
    new Surah 
    {
        Id = 86,
        NameArabic = "سُورَةُ الطَّارِقِ",
        NameTransliteration = "At-Taariq",
        NameEnglish = "The Morning Star",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 17,
        DisplayOrder = 86,
        SearchNormalizedArabic = "سورة الطارق",
        IsPublished = true
    },
    new Surah 
    {
        Id = 87,
        NameArabic = "سُورَةُ الأَعۡلَىٰ",
        NameTransliteration = "Al-A'laa",
        NameEnglish = "The Most High",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 19,
        DisplayOrder = 87,
        SearchNormalizedArabic = "سورة الأعۡلىٰ",
        IsPublished = true
    },
    new Surah 
    {
        Id = 88,
        NameArabic = "سُورَةُ الغَاشِيَةِ",
        NameTransliteration = "Al-Ghaashiya",
        NameEnglish = "The Overwhelming",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 26,
        DisplayOrder = 88,
        SearchNormalizedArabic = "سورة الغاشية",
        IsPublished = true
    },
    new Surah 
    {
        Id = 89,
        NameArabic = "سُورَةُ الفَجۡرِ",
        NameTransliteration = "Al-Fajr",
        NameEnglish = "The Dawn",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 30,
        DisplayOrder = 89,
        SearchNormalizedArabic = "سورة الفجۡر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 90,
        NameArabic = "سُورَةُ البَلَدِ",
        NameTransliteration = "Al-Balad",
        NameEnglish = "The City",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 20,
        DisplayOrder = 90,
        SearchNormalizedArabic = "سورة البلد",
        IsPublished = true
    },
    new Surah 
    {
        Id = 91,
        NameArabic = "سُورَةُ الشَّمۡسِ",
        NameTransliteration = "Ash-Shams",
        NameEnglish = "The Sun",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 15,
        DisplayOrder = 91,
        SearchNormalizedArabic = "سورة الشمۡس",
        IsPublished = true
    },
    new Surah 
    {
        Id = 92,
        NameArabic = "سُورَةُ اللَّيۡلِ",
        NameTransliteration = "Al-Lail",
        NameEnglish = "The Night",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 21,
        DisplayOrder = 92,
        SearchNormalizedArabic = "سورة الليۡل",
        IsPublished = true
    },
    new Surah 
    {
        Id = 93,
        NameArabic = "سُورَةُ الضُّحَىٰ",
        NameTransliteration = "Ad-Dhuhaa",
        NameEnglish = "The Morning Hours",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 11,
        DisplayOrder = 93,
        SearchNormalizedArabic = "سورة الضحىٰ",
        IsPublished = true
    },
    new Surah 
    {
        Id = 94,
        NameArabic = "سُورَةُ الشَّرۡحِ",
        NameTransliteration = "Ash-Sharh",
        NameEnglish = "The Consolation",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 8,
        DisplayOrder = 94,
        SearchNormalizedArabic = "سورة الشرۡح",
        IsPublished = true
    },
    new Surah 
    {
        Id = 95,
        NameArabic = "سُورَةُ التِّينِ",
        NameTransliteration = "At-Tin",
        NameEnglish = "The Fig",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 8,
        DisplayOrder = 95,
        SearchNormalizedArabic = "سورة التين",
        IsPublished = true
    },
    new Surah 
    {
        Id = 96,
        NameArabic = "سُورَةُ العَلَقِ",
        NameTransliteration = "Al-Alaq",
        NameEnglish = "The Clot",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 19,
        DisplayOrder = 96,
        SearchNormalizedArabic = "سورة العلق",
        IsPublished = true
    },
    new Surah 
    {
        Id = 97,
        NameArabic = "سُورَةُ القَدۡرِ",
        NameTransliteration = "Al-Qadr",
        NameEnglish = "The Power, Fate",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 5,
        DisplayOrder = 97,
        SearchNormalizedArabic = "سورة القدۡر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 98,
        NameArabic = "سُورَةُ البَيِّنَةِ",
        NameTransliteration = "Al-Bayyina",
        NameEnglish = "The Evidence",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 8,
        DisplayOrder = 98,
        SearchNormalizedArabic = "سورة البينة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 99,
        NameArabic = "سُورَةُ الزَّلۡزَلَةِ",
        NameTransliteration = "Az-Zalzala",
        NameEnglish = "The Earthquake",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 8,
        DisplayOrder = 99,
        SearchNormalizedArabic = "سورة الزلۡزلة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 100,
        NameArabic = "سُورَةُ العَادِيَاتِ",
        NameTransliteration = "Al-Aadiyaat",
        NameEnglish = "The Chargers",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 11,
        DisplayOrder = 100,
        SearchNormalizedArabic = "سورة العاديات",
        IsPublished = true
    },
    new Surah 
    {
        Id = 101,
        NameArabic = "سُورَةُ القَارِعَةِ",
        NameTransliteration = "Al-Qaari'a",
        NameEnglish = "The Calamity",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 11,
        DisplayOrder = 101,
        SearchNormalizedArabic = "سورة القارعة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 102,
        NameArabic = "سُورَةُ التَّكَاثُرِ",
        NameTransliteration = "At-Takaathur",
        NameEnglish = "Competition",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 8,
        DisplayOrder = 102,
        SearchNormalizedArabic = "سورة التكاثر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 103,
        NameArabic = "سُورَةُ العَصۡرِ",
        NameTransliteration = "Al-Asr",
        NameEnglish = "The Declining Day, Epoch",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 3,
        DisplayOrder = 103,
        SearchNormalizedArabic = "سورة العصۡر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 104,
        NameArabic = "سُورَةُ الهُمَزَةِ",
        NameTransliteration = "Al-Humaza",
        NameEnglish = "The Traducer",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 9,
        DisplayOrder = 104,
        SearchNormalizedArabic = "سورة الهمزة",
        IsPublished = true
    },
    new Surah 
    {
        Id = 105,
        NameArabic = "سُورَةُ الفِيلِ",
        NameTransliteration = "Al-Fil",
        NameEnglish = "The Elephant",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 5,
        DisplayOrder = 105,
        SearchNormalizedArabic = "سورة الفيل",
        IsPublished = true
    },
    new Surah 
    {
        Id = 106,
        NameArabic = "سُورَةُ قُرَيۡشٍ",
        NameTransliteration = "Quraish",
        NameEnglish = "Quraysh",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 4,
        DisplayOrder = 106,
        SearchNormalizedArabic = "سورة قريۡش",
        IsPublished = true
    },
    new Surah 
    {
        Id = 107,
        NameArabic = "سُورَةُ المَاعُونِ",
        NameTransliteration = "Al-Maa'un",
        NameEnglish = "Almsgiving",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 7,
        DisplayOrder = 107,
        SearchNormalizedArabic = "سورة الماعون",
        IsPublished = true
    },
    new Surah 
    {
        Id = 108,
        NameArabic = "سُورَةُ الكَوۡثَرِ",
        NameTransliteration = "Al-Kawthar",
        NameEnglish = "Abundance",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 3,
        DisplayOrder = 108,
        SearchNormalizedArabic = "سورة الكوۡثر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 109,
        NameArabic = "سُورَةُ الكَافِرُونَ",
        NameTransliteration = "Al-Kaafiroon",
        NameEnglish = "The Disbelievers",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 6,
        DisplayOrder = 109,
        SearchNormalizedArabic = "سورة الكافرون",
        IsPublished = true
    },
    new Surah 
    {
        Id = 110,
        NameArabic = "سُورَةُ النَّصۡرِ",
        NameTransliteration = "An-Nasr",
        NameEnglish = "Divine Support",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Madani,
        VerseCount = 3,
        DisplayOrder = 110,
        SearchNormalizedArabic = "سورة النصۡر",
        IsPublished = true
    },
    new Surah 
    {
        Id = 111,
        NameArabic = "سُورَةُ المَسَدِ",
        NameTransliteration = "Al-Masad",
        NameEnglish = "The Palm Fibre",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 5,
        DisplayOrder = 111,
        SearchNormalizedArabic = "سورة المسد",
        IsPublished = true
    },
    new Surah 
    {
        Id = 112,
        NameArabic = "سُورَةُ الإِخۡلَاصِ",
        NameTransliteration = "Al-Ikhlaas",
        NameEnglish = "Sincerity",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 4,
        DisplayOrder = 112,
        SearchNormalizedArabic = "سورة الإخۡلاص",
        IsPublished = true
    },
    new Surah 
    {
        Id = 113,
        NameArabic = "سُورَةُ الفَلَقِ",
        NameTransliteration = "Al-Falaq",
        NameEnglish = "The Dawn",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 5,
        DisplayOrder = 113,
        SearchNormalizedArabic = "سورة الفلق",
        IsPublished = true
    },
    new Surah 
    {
        Id = 114,
        NameArabic = "سُورَةُ النَّاسِ",
        NameTransliteration = "An-Naas",
        NameEnglish = "Mankind",
        RevelationType = HassanAdly.Domain.Enums.RevelationType.Makki,
        VerseCount = 6,
        DisplayOrder = 114,
        SearchNormalizedArabic = "سورة الناس",
        IsPublished = true
    }
);

    }
}

