using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HassanAdly.Persistence.Data;

public sealed class AppDbContextInitialiser
{
    private readonly ILogger<AppDbContextInitialiser> _logger;
    private readonly AppDbContext _dbContext;
    private readonly IHostEnvironment _hostEnvironment;

    public AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, AppDbContext dbContext, IHostEnvironment hostEnvironment)
    {
        _logger = logger;
        _dbContext = dbContext;
        _hostEnvironment = hostEnvironment;
    }

    public async Task InitialiseAsync(CancellationToken cancellationToken)
    {
        try
        {
            var hasMigrations = _dbContext.Database.GetMigrations().Any();
            if (!hasMigrations)
            {
                if (_hostEnvironment.IsDevelopment())
                {
                    await _dbContext.Database.EnsureDeletedAsync(cancellationToken);
                }

                await _dbContext.Database.EnsureCreatedAsync(cancellationToken);
                return;
            }

            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        try
        {
            await TrySeedAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync(CancellationToken cancellationToken)
    {
        // Add Qiraa
        if (!await _dbContext.Qiraat.AnyAsync(cancellationToken))
        {
            _dbContext.Qiraat.Add(new Domain.Entities.Qiraa
            {
                Id = 0,
                Slug = "hafs-an-asim",
                NameArabic = "حفص عن عاصم",
                NameEnglish = "Hafs 'an 'Asim",
                RawiArabic = "حفص",
                ImamArabic = "عاصم",
                DescriptionArabic = "رواية حفص عن عاصم هي القراءة الأكثر انتشارا في العالم الإسلامي.",
                DisplayOrder = 1,
                IsPublished = true
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // Add Sheikh
        if (!await _dbContext.Sheikhs.AnyAsync(cancellationToken))
        {
            var sheikh = new Domain.Entities.Sheikh
            {
                Id = 0,
                Slug = "hassan-adly",
                DisplayNameArabic = "حسن عدلي",
                DisplayNameEnglish = "Hassan Adly",
                FullNameArabic = "حسن بن عدلي",
                BiographyArabic = "سيرة الشيخ حسن عدلي...",
                ShortDescriptionArabic = "الشيخ حسن عدلي",
                ProfileImageUrl = "https://example.com/profile.jpg",
                IsActive = true,
                BirthDate = new DateOnly(1980, 1, 1),
                BirthPlaceArabic = "مصر",
                HeroImageUrl = "https://example.com/hero.jpg",
                HeroTitleArabic = "الشيخ حسن عدلي",
                HeroSubtitleArabic = "عالم وقارئ للقرآن الكريم"
            };
            _dbContext.Sheikhs.Add(sheikh);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Add Sheikh Education
            _dbContext.SheikhEducationEntries.Add(new Domain.Entities.SheikhEducation
            {
                Id = 0,
                SheikhId = sheikh.Id,
                TitleArabic = "الإجازات والدراسات",
                InstitutionArabic = "جامعة الأزهر",
                DescriptionArabic = "دراسة القراءات العشر",
                DisplayOrder = 1
            });

            // Add Sheikh Experience
            _dbContext.SheikhExperienceEntries.Add(new Domain.Entities.SheikhExperience
            {
                Id = 0,
                SheikhId = sheikh.Id,
                TitleArabic = "إمامة المصلين",
                DescriptionArabic = "إمام مسجد متطوع",
                DisplayOrder = 1
            });

            // Add Sheikh Teachers
            _dbContext.SheikhTeachers.Add(new Domain.Entities.SheikhTeacher
            {
                Id = 0,
                SheikhId = sheikh.Id,
                NameArabic = "الشيخ عبدالباسط",
                DescriptionArabic = "أحد معلمي الشيخ الأساسيين",
                DisplayOrder = 1
            });

            // Add Sheikh HighlightCard
            _dbContext.SheikhHighlightCards.Add(new Domain.Entities.SheikhHighlightCard
            {
                Id = 0,
                SheikhId = sheikh.Id,
                TitleArabic = "إنجازات",
                BodyArabic = "إتمام القراءات العشر",
                ImageUrl = "https://example.com/highlight.jpg",
                DisplayOrder = 1
            });

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // Add Surah
        if (!await _dbContext.Surahs.AnyAsync(cancellationToken))
        {
            var surah = new Domain.Entities.Surah
            {
                Id = 0,
                NameArabic = "الفاتحة",
                NameTransliteration = "Al-Fatihah",
                NameEnglish = "The Opener",
                RevelationType = Domain.Enums.RevelationType.Makki,
                VerseCount = 7,
                DisplayOrder = 1,
                SearchNormalizedArabic = "الفاتحة",
                IsPublished = true
            };
            _dbContext.Surahs.Add(surah);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Add Ayat
            var ayat = new List<Domain.Entities.Ayah>
            {
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 1, TextUthmani = "بِسْمِ ٱللَّهِ ٱلرَّحْمَـٰنِ ٱلرَّحِيمِ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 1 },
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 2, TextUthmani = "ٱلْحَمْدُ لِلَّهِ رَبِّ ٱلْعَـٰلَمِينَ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 2 },
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 3, TextUthmani = "ٱلرَّحْمَـٰنِ ٱلرَّحِيمِ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 3 },
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 4, TextUthmani = "مَـٰلِكِ يَوْمِ ٱلدِّينِ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 4 },
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 5, TextUthmani = "إِيَّاكَ نَعْبُدُ وَإِيَّاكَ نَسْتَعِينُ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 5 },
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 6, TextUthmani = "ٱهْدِنَا ٱلصِّرَٰطَ ٱلْمُسْتَقِيمَ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 6 },
                new Domain.Entities.Ayah { Id = 0, SurahId = surah.Id, AyahNumber = 7, TextUthmani = "صِرَٰطَ ٱلَّذِينَ أَنْعَمْتَ عَلَيْهِمْ غَيْرِ ٱلْمَغْضُوبِ عَلَيْهِمْ وَلَا ٱلضَّآلِّينَ", Juz = 1, Hizb = 1, PageNumber = 1, GlobalAyahNumber = 7 }
            };
            _dbContext.Ayat.AddRange(ayat);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Add AudioTrack
            var sheikh = await _dbContext.Sheikhs.FirstAsync(cancellationToken);
            var qiraa = await _dbContext.Qiraat.FirstAsync(cancellationToken);
            var audioTrack = new Domain.Entities.AudioTrack
            {
                Id = 0,
                SheikhId = sheikh.Id,
                SurahId = surah.Id,
                QiraaId = qiraa.Id,
                TitleArabic = "تلاوة الفاتحة",
                AudioObjectKey = "surahs/hafs/alfatihah.mp3",
                DurationSeconds = 60,
                FileSizeBytes = 1024000,
                BitrateKbps = 128,
                Status = Domain.Enums.AudioTrackStatus.Published
            };
            _dbContext.AudioTracks.Add(audioTrack);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Add AyahTiming
            _dbContext.AyahTimings.Add(new Domain.Entities.AyahTiming
            {
                Id = 0,
                AudioTrackId = audioTrack.Id,
                AyahId = ayat[0].Id,
                StartTimeMs = 0,
                EndTimeMs = 5000
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // Add Featured Content
        if (!await _dbContext.FeaturedContents.AnyAsync(cancellationToken))
        {
            _dbContext.FeaturedContents.Add(new Domain.Entities.FeaturedContent
            {
                Id = 0,
                TitleArabic = "المحتوى المميز",
                SubtitleArabic = "اكتشف أحدث التلاوات",
                ImageUrl = "https://example.com/featured.jpg",
                LinkUrl = "/surah/1",
                DisplayOrder = 1,
                IsPublished = true
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        // Add MediaAsset
        if (!await _dbContext.MediaAssets.AnyAsync(cancellationToken))
        {
            _dbContext.MediaAssets.Add(new Domain.Entities.MediaAsset
            {
                Id = 0,
                ObjectKey = "images/hero.jpg",
                PublicUrl = "https://example.com/hero.jpg",
                ContentType = "image/jpeg",
                SizeBytes = 512000
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
