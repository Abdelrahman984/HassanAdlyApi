using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HassanAdly.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAndRemoveAuditableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedContents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleArabic = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    SubtitleArabic = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LinkUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaAssets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectKey = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PublicUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qiraat",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RawiArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ImamArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qiraat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sheikhs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayNameArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DisplayNameEnglish = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    FullNameArabic = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BirthPlaceArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BiographyArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescriptionArabic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    HeroImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    HeroTitleArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    HeroSubtitleArabic = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheikhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surahs",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    NameArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    NameTransliteration = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SeoTitleArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    SeoDescriptionArabic = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SeoTitleEnglish = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    SeoDescriptionEnglish = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RevelationType = table.Column<byte>(type: "tinyint", nullable: false),
                    VerseCount = table.Column<short>(type: "smallint", nullable: false),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    SearchNormalizedArabic = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surahs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUserId = table.Column<long>(type: "bigint", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExpiresAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RevokedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminRefreshTokens_AdminUsers_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "AdminUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SheikhEducationEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheikhId = table.Column<long>(type: "bigint", nullable: false),
                    TitleArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    InstitutionArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheikhEducationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheikhEducationEntries_Sheikhs_SheikhId",
                        column: x => x.SheikhId,
                        principalTable: "Sheikhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SheikhExperienceEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheikhId = table.Column<long>(type: "bigint", nullable: false),
                    TitleArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheikhExperienceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheikhExperienceEntries_Sheikhs_SheikhId",
                        column: x => x.SheikhId,
                        principalTable: "Sheikhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SheikhHighlightCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheikhId = table.Column<long>(type: "bigint", nullable: false),
                    TitleArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    BodyArabic = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheikhHighlightCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheikhHighlightCards_Sheikhs_SheikhId",
                        column: x => x.SheikhId,
                        principalTable: "Sheikhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SheikhTeachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheikhId = table.Column<long>(type: "bigint", nullable: false),
                    NameArabic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DescriptionArabic = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheikhTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SheikhTeachers_Sheikhs_SheikhId",
                        column: x => x.SheikhId,
                        principalTable: "Sheikhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioTracks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheikhId = table.Column<long>(type: "bigint", nullable: false),
                    SurahId = table.Column<short>(type: "smallint", nullable: false),
                    QiraaId = table.Column<short>(type: "smallint", nullable: false),
                    TitleArabic = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    AudioObjectKey = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DurationSeconds = table.Column<int>(type: "int", nullable: false),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    BitrateKbps = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Checksum = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioTracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioTracks_Qiraat_QiraaId",
                        column: x => x.QiraaId,
                        principalTable: "Qiraat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioTracks_Sheikhs_SheikhId",
                        column: x => x.SheikhId,
                        principalTable: "Sheikhs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioTracks_Surahs_SurahId",
                        column: x => x.SurahId,
                        principalTable: "Surahs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ayat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurahId = table.Column<short>(type: "smallint", nullable: false),
                    AyahNumber = table.Column<short>(type: "smallint", nullable: false),
                    GlobalAyahNumber = table.Column<int>(type: "int", nullable: true),
                    TextUthmani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Juz = table.Column<byte>(type: "tinyint", nullable: false),
                    Hizb = table.Column<byte>(type: "tinyint", nullable: false),
                    PageNumber = table.Column<short>(type: "smallint", nullable: false),
                    RubElHizb = table.Column<byte>(type: "tinyint", nullable: true),
                    SajdahType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ayat_Surahs_SurahId",
                        column: x => x.SurahId,
                        principalTable: "Surahs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AyahTimings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioTrackId = table.Column<long>(type: "bigint", nullable: false),
                    AyahId = table.Column<long>(type: "bigint", nullable: false),
                    StartTimeMs = table.Column<int>(type: "int", nullable: false),
                    EndTimeMs = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AyahTimings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AyahTimings_AudioTracks_AudioTrackId",
                        column: x => x.AudioTrackId,
                        principalTable: "AudioTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AyahTimings_Ayat_AyahId",
                        column: x => x.AyahId,
                        principalTable: "Ayat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Qiraat",
                columns: new[] { "Id", "DescriptionArabic", "DisplayOrder", "ImamArabic", "IsPublished", "NameArabic", "NameEnglish", "RawiArabic", "Slug" },
                values: new object[,]
                {
                    { (short)1, null, (short)1, "عاصم", true, "حفص عن عاصم", "Hafs an Asim", "حفص", "hafs-an-asim" },
                    { (short)2, null, (short)2, "عاصم", true, "شعبة عن عاصم", "Shu'bah an Asim", "شعبة", "shubah-an-asim" },
                    { (short)3, null, (short)3, "نافع", true, "ورش عن نافع", "Warsh an Nafi", "ورش", "warsh-an-nafi" },
                    { (short)4, null, (short)4, "نافع", true, "قالون عن نافع", "Qalun an Nafi", "قالون", "qalun-an-nafi" },
                    { (short)5, null, (short)5, "ابن كثير", true, "البزي عن ابن كثير", "Al-Bazzi an Ibn Kathir", "البزي", "al-bazzi-an-ibn-kathir" },
                    { (short)6, null, (short)6, "ابن كثير", true, "قنبل عن ابن كثير", "Qunbul an Ibn Kathir", "قنبل", "qunbul-an-ibn-kathir" },
                    { (short)7, null, (short)7, "أبو عمرو", true, "الدوري عن أبي عمرو", "Al-Duri an Abu Amr", "الدوري", "al-duri-an-abu-amr" },
                    { (short)8, null, (short)8, "أبو عمرو", true, "السوسي عن أبي عمرو", "As-Susi an Abu Amr", "السوسي", "as-susi-an-abu-amr" },
                    { (short)9, null, (short)9, "ابن عامر", true, "هشام عن ابن عامر", "Hisham an Ibn Amir", "هشام", "hisham-an-ibn-amir" },
                    { (short)10, null, (short)10, "ابن عامر", true, "ابن ذكوان عن ابن عامر", "Ibn Dhakwan an Ibn Amir", "ابن ذكوان", "ibn-dhakwan-an-ibn-amir" }
                });

            migrationBuilder.InsertData(
                table: "Sheikhs",
                columns: new[] { "Id", "BiographyArabic", "BirthDate", "BirthPlaceArabic", "DisplayNameArabic", "DisplayNameEnglish", "FullNameArabic", "HeroImageUrl", "HeroSubtitleArabic", "HeroTitleArabic", "IsActive", "ProfileImageUrl", "ShortDescriptionArabic", "Slug" },
                values: new object[] { 1L, "قارئ القرآن الكريم", new DateOnly(1980, 1, 1), "مصر", "حسن عدلي", "Hassan Adly", "حسن بن محمد مصطفى عدلي", "/images/hero-bg.jpg", "المقرئ بالقراءات العشر", "الشيخ حسن عدلي", true, "/images/hassan-adly-profile.jpg", "قارئ ومقرئ للقرآن الكريم", "hassan-adly" });

            migrationBuilder.InsertData(
                table: "Surahs",
                columns: new[] { "Id", "DisplayOrder", "IsPublished", "NameArabic", "NameEnglish", "NameTransliteration", "RevelationType", "SearchNormalizedArabic", "SeoDescriptionArabic", "SeoDescriptionEnglish", "SeoTitleArabic", "SeoTitleEnglish", "VerseCount" },
                values: new object[,]
                {
                    { (short)1, (short)1, true, "سُورَةُ ٱلْفَاتِحَةِ", "The Opening", "Al-Faatiha", (byte)1, "سورة ٱلفاتحة", null, null, null, null, (short)7 },
                    { (short)2, (short)2, true, "سُورَةُ البَقَرَةِ", "The Cow", "Al-Baqara", (byte)2, "سورة البقرة", null, null, null, null, (short)286 },
                    { (short)3, (short)3, true, "سُورَةُ آلِ عِمۡرَانَ", "The Family of Imraan", "Aal-i-Imraan", (byte)2, "سورة ال عمۡران", null, null, null, null, (short)200 },
                    { (short)4, (short)4, true, "سُورَةُ النِّسَاءِ", "The Women", "An-Nisaa", (byte)2, "سورة النساء", null, null, null, null, (short)176 },
                    { (short)5, (short)5, true, "سُورَةُ المَائـِدَةِ", "The Table", "Al-Maaida", (byte)2, "سورة المائـدة", null, null, null, null, (short)120 },
                    { (short)6, (short)6, true, "سُورَةُ الأَنۡعَامِ", "The Cattle", "Al-An'aam", (byte)1, "سورة الأنۡعام", null, null, null, null, (short)165 },
                    { (short)7, (short)7, true, "سُورَةُ الأَعۡرَافِ", "The Heights", "Al-A'raaf", (byte)1, "سورة الأعۡراف", null, null, null, null, (short)206 },
                    { (short)8, (short)8, true, "سُورَةُ الأَنفَالِ", "The Spoils of War", "Al-Anfaal", (byte)2, "سورة الأنفال", null, null, null, null, (short)75 },
                    { (short)9, (short)9, true, "سُورَةُ التَّوۡبَةِ", "The Repentance", "At-Tawba", (byte)2, "سورة التوۡبة", null, null, null, null, (short)129 },
                    { (short)10, (short)10, true, "سُورَةُ يُونُسَ", "Jonas", "Yunus", (byte)1, "سورة يونس", null, null, null, null, (short)109 },
                    { (short)11, (short)11, true, "سُورَةُ هُودٍ", "Hud", "Hud", (byte)1, "سورة هود", null, null, null, null, (short)123 },
                    { (short)12, (short)12, true, "سُورَةُ يُوسُفَ", "Joseph", "Yusuf", (byte)1, "سورة يوسف", null, null, null, null, (short)111 },
                    { (short)13, (short)13, true, "سُورَةُ الرَّعۡدِ", "The Thunder", "Ar-Ra'd", (byte)2, "سورة الرعۡد", null, null, null, null, (short)43 },
                    { (short)14, (short)14, true, "سُورَةُ إِبۡرَاهِيمَ", "Abraham", "Ibrahim", (byte)1, "سورة إبۡراهيم", null, null, null, null, (short)52 },
                    { (short)15, (short)15, true, "سُورَةُ الحِجۡرِ", "The Rock", "Al-Hijr", (byte)1, "سورة الحجۡر", null, null, null, null, (short)99 },
                    { (short)16, (short)16, true, "سُورَةُ النَّحۡلِ", "The Bee", "An-Nahl", (byte)1, "سورة النحۡل", null, null, null, null, (short)128 },
                    { (short)17, (short)17, true, "سُورَةُ الإِسۡرَاءِ", "The Night Journey", "Al-Israa", (byte)1, "سورة الإسۡراء", null, null, null, null, (short)111 },
                    { (short)18, (short)18, true, "سُورَةُ الكَهۡفِ", "The Cave", "Al-Kahf", (byte)1, "سورة الكهۡف", null, null, null, null, (short)110 },
                    { (short)19, (short)19, true, "سُورَةُ مَرۡيَمَ", "Mary", "Maryam", (byte)1, "سورة مرۡيم", null, null, null, null, (short)98 },
                    { (short)20, (short)20, true, "سُورَةُ طه", "Taa-Haa", "Taa-Haa", (byte)1, "سورة طه", null, null, null, null, (short)135 },
                    { (short)21, (short)21, true, "سُورَةُ الأَنبِيَاءِ", "The Prophets", "Al-Anbiyaa", (byte)1, "سورة الأنبياء", null, null, null, null, (short)112 },
                    { (short)22, (short)22, true, "سُورَةُ الحَجِّ", "The Pilgrimage", "Al-Hajj", (byte)2, "سورة الحج", null, null, null, null, (short)78 },
                    { (short)23, (short)23, true, "سُورَةُ المُؤۡمِنُونَ", "The Believers", "Al-Muminoon", (byte)1, "سورة المؤۡمنون", null, null, null, null, (short)118 },
                    { (short)24, (short)24, true, "سُورَةُ النُّورِ", "The Light", "An-Noor", (byte)2, "سورة النور", null, null, null, null, (short)64 },
                    { (short)25, (short)25, true, "سُورَةُ الفُرۡقَانِ", "The Criterion", "Al-Furqaan", (byte)1, "سورة الفرۡقان", null, null, null, null, (short)77 },
                    { (short)26, (short)26, true, "سُورَةُ الشُّعَرَاءِ", "The Poets", "Ash-Shu'araa", (byte)1, "سورة الشعراء", null, null, null, null, (short)227 },
                    { (short)27, (short)27, true, "سُورَةُ النَّمۡلِ", "The Ant", "An-Naml", (byte)1, "سورة النمۡل", null, null, null, null, (short)93 },
                    { (short)28, (short)28, true, "سُورَةُ القَصَصِ", "The Stories", "Al-Qasas", (byte)1, "سورة القصص", null, null, null, null, (short)88 },
                    { (short)29, (short)29, true, "سُورَةُ العَنكَبُوتِ", "The Spider", "Al-Ankaboot", (byte)1, "سورة العنكبوت", null, null, null, null, (short)69 },
                    { (short)30, (short)30, true, "سُورَةُ الرُّومِ", "The Romans", "Ar-Room", (byte)1, "سورة الروم", null, null, null, null, (short)60 },
                    { (short)31, (short)31, true, "سُورَةُ لُقۡمَانَ", "Luqman", "Luqman", (byte)1, "سورة لقۡمان", null, null, null, null, (short)34 },
                    { (short)32, (short)32, true, "سُورَةُ السَّجۡدَةِ", "The Prostration", "As-Sajda", (byte)1, "سورة السجۡدة", null, null, null, null, (short)30 },
                    { (short)33, (short)33, true, "سُورَةُ الأَحۡزَابِ", "The Clans", "Al-Ahzaab", (byte)2, "سورة الأحۡزاب", null, null, null, null, (short)73 },
                    { (short)34, (short)34, true, "سُورَةُ سَبَإٍ", "Sheba", "Saba", (byte)1, "سورة سبإ", null, null, null, null, (short)54 },
                    { (short)35, (short)35, true, "سُورَةُ فَاطِرٍ", "The Originator", "Faatir", (byte)1, "سورة فاطر", null, null, null, null, (short)45 },
                    { (short)36, (short)36, true, "سُورَةُ يسٓ", "Yaseen", "Yaseen", (byte)1, "سورة يس", null, null, null, null, (short)83 },
                    { (short)37, (short)37, true, "سُورَةُ الصَّافَّاتِ", "Those drawn up in Ranks", "As-Saaffaat", (byte)1, "سورة الصافات", null, null, null, null, (short)182 },
                    { (short)38, (short)38, true, "سُورَةُ صٓ", "The letter Saad", "Saad", (byte)1, "سورة ص", null, null, null, null, (short)88 },
                    { (short)39, (short)39, true, "سُورَةُ الزُّمَرِ", "The Groups", "Az-Zumar", (byte)1, "سورة الزمر", null, null, null, null, (short)75 },
                    { (short)40, (short)40, true, "سُورَةُ غَافِرٍ", "The Forgiver", "Ghafir", (byte)1, "سورة غافر", null, null, null, null, (short)85 },
                    { (short)41, (short)41, true, "سُورَةُ فُصِّلَتۡ", "Explained in detail", "Fussilat", (byte)1, "سورة فصلتۡ", null, null, null, null, (short)54 },
                    { (short)42, (short)42, true, "سُورَةُ الشُّورَىٰ", "Consultation", "Ash-Shura", (byte)1, "سورة الشورىٰ", null, null, null, null, (short)53 },
                    { (short)43, (short)43, true, "سُورَةُ الزُّخۡرُفِ", "Ornaments of gold", "Az-Zukhruf", (byte)1, "سورة الزخۡرف", null, null, null, null, (short)89 },
                    { (short)44, (short)44, true, "سُورَةُ الدُّخَانِ", "The Smoke", "Ad-Dukhaan", (byte)1, "سورة الدخان", null, null, null, null, (short)59 },
                    { (short)45, (short)45, true, "سُورَةُ الجَاثِيَةِ", "Crouching", "Al-Jaathiya", (byte)1, "سورة الجاثية", null, null, null, null, (short)37 },
                    { (short)46, (short)46, true, "سُورَةُ الأَحۡقَافِ", "The Dunes", "Al-Ahqaf", (byte)1, "سورة الأحۡقاف", null, null, null, null, (short)35 },
                    { (short)47, (short)47, true, "سُورَةُ مُحَمَّدٍ", "Muhammad", "Muhammad", (byte)2, "سورة محمد", null, null, null, null, (short)38 },
                    { (short)48, (short)48, true, "سُورَةُ الفَتۡحِ", "The Victory", "Al-Fath", (byte)2, "سورة الفتۡح", null, null, null, null, (short)29 },
                    { (short)49, (short)49, true, "سُورَةُ الحُجُرَاتِ", "The Inner Apartments", "Al-Hujuraat", (byte)2, "سورة الحجرات", null, null, null, null, (short)18 },
                    { (short)50, (short)50, true, "سُورَةُ قٓ", "The letter Qaaf", "Qaaf", (byte)1, "سورة ق", null, null, null, null, (short)45 },
                    { (short)51, (short)51, true, "سُورَةُ الذَّارِيَاتِ", "The Winnowing Winds", "Adh-Dhaariyat", (byte)1, "سورة الذاريات", null, null, null, null, (short)60 },
                    { (short)52, (short)52, true, "سُورَةُ الطُّورِ", "The Mount", "At-Tur", (byte)1, "سورة الطور", null, null, null, null, (short)49 },
                    { (short)53, (short)53, true, "سُورَةُ النَّجۡمِ", "The Star", "An-Najm", (byte)1, "سورة النجۡم", null, null, null, null, (short)62 },
                    { (short)54, (short)54, true, "سُورَةُ القَمَرِ", "The Moon", "Al-Qamar", (byte)1, "سورة القمر", null, null, null, null, (short)55 },
                    { (short)55, (short)55, true, "سُورَةُ الرَّحۡمَٰن", "The Beneficent", "Ar-Rahmaan", (byte)2, "سورة الرحۡمٰن", null, null, null, null, (short)78 },
                    { (short)56, (short)56, true, "سُورَةُ الوَاقِعَةِ", "The Inevitable", "Al-Waaqia", (byte)1, "سورة الواقعة", null, null, null, null, (short)96 },
                    { (short)57, (short)57, true, "سُورَةُ الحَدِيدِ", "The Iron", "Al-Hadid", (byte)2, "سورة الحديد", null, null, null, null, (short)29 },
                    { (short)58, (short)58, true, "سُورَةُ المُجَادلَةِ", "The Pleading Woman", "Al-Mujaadila", (byte)2, "سورة المجادلة", null, null, null, null, (short)22 },
                    { (short)59, (short)59, true, "سُورَةُ الحَشۡرِ", "The Exile", "Al-Hashr", (byte)2, "سورة الحشۡر", null, null, null, null, (short)24 },
                    { (short)60, (short)60, true, "سُورَةُ المُمۡتَحنَةِ", "She that is to be examined", "Al-Mumtahana", (byte)2, "سورة الممۡتحنة", null, null, null, null, (short)13 },
                    { (short)61, (short)61, true, "سُورَةُ الصَّفِّ", "The Ranks", "As-Saff", (byte)2, "سورة الصف", null, null, null, null, (short)14 },
                    { (short)62, (short)62, true, "سُورَةُ الجُمُعَةِ", "Friday", "Al-Jumu'a", (byte)2, "سورة الجمعة", null, null, null, null, (short)11 },
                    { (short)63, (short)63, true, "سُورَةُ المُنَافِقُونَ", "The Hypocrites", "Al-Munaafiqoon", (byte)2, "سورة المنافقون", null, null, null, null, (short)11 },
                    { (short)64, (short)64, true, "سُورَةُ التَّغَابُنِ", "Mutual Disillusion", "At-Taghaabun", (byte)2, "سورة التغابن", null, null, null, null, (short)18 },
                    { (short)65, (short)65, true, "سُورَةُ الطَّلَاقِ", "Divorce", "At-Talaaq", (byte)2, "سورة الطلاق", null, null, null, null, (short)12 },
                    { (short)66, (short)66, true, "سُورَةُ التَّحۡرِيمِ", "The Prohibition", "At-Tahrim", (byte)2, "سورة التحۡريم", null, null, null, null, (short)12 },
                    { (short)67, (short)67, true, "سُورَةُ المُلۡكِ", "The Sovereignty", "Al-Mulk", (byte)1, "سورة الملۡك", null, null, null, null, (short)30 },
                    { (short)68, (short)68, true, "سُورَةُ القَلَمِ", "The Pen", "Al-Qalam", (byte)1, "سورة القلم", null, null, null, null, (short)52 },
                    { (short)69, (short)69, true, "سُورَةُ الحَاقَّةِ", "The Reality", "Al-Haaqqa", (byte)1, "سورة الحاقة", null, null, null, null, (short)52 },
                    { (short)70, (short)70, true, "سُورَةُ المَعَارِجِ", "The Ascending Stairways", "Al-Ma'aarij", (byte)1, "سورة المعارج", null, null, null, null, (short)44 },
                    { (short)71, (short)71, true, "سُورَةُ نُوحٍ", "Noah", "Nooh", (byte)1, "سورة نوح", null, null, null, null, (short)28 },
                    { (short)72, (short)72, true, "سُورَةُ الجِنِّ", "The Jinn", "Al-Jinn", (byte)1, "سورة الجن", null, null, null, null, (short)28 },
                    { (short)73, (short)73, true, "سُورَةُ المُزَّمِّلِ", "The Enshrouded One", "Al-Muzzammil", (byte)1, "سورة المزمل", null, null, null, null, (short)20 },
                    { (short)74, (short)74, true, "سُورَةُ المُدَّثِّرِ", "The Cloaked One", "Al-Muddaththir", (byte)1, "سورة المدثر", null, null, null, null, (short)56 },
                    { (short)75, (short)75, true, "سُورَةُ القِيَامَةِ", "The Resurrection", "Al-Qiyaama", (byte)1, "سورة القيامة", null, null, null, null, (short)40 },
                    { (short)76, (short)76, true, "سُورَةُ الإِنسَانِ", "Man", "Al-Insaan", (byte)2, "سورة الإنسان", null, null, null, null, (short)31 },
                    { (short)77, (short)77, true, "سُورَةُ المُرۡسَلَاتِ", "The Emissaries", "Al-Mursalaat", (byte)1, "سورة المرۡسلات", null, null, null, null, (short)50 },
                    { (short)78, (short)78, true, "سُورَةُ النَّبَإِ", "The Announcement", "An-Naba", (byte)1, "سورة النبإ", null, null, null, null, (short)40 },
                    { (short)79, (short)79, true, "سُورَةُ النَّازِعَاتِ", "Those who drag forth", "An-Naazi'aat", (byte)1, "سورة النازعات", null, null, null, null, (short)46 },
                    { (short)80, (short)80, true, "سُورَةُ عَبَسَ", "He frowned", "Abasa", (byte)1, "سورة عبس", null, null, null, null, (short)42 },
                    { (short)81, (short)81, true, "سُورَةُ التَّكۡوِيرِ", "The Overthrowing", "At-Takwir", (byte)1, "سورة التكۡوير", null, null, null, null, (short)29 },
                    { (short)82, (short)82, true, "سُورَةُ الانفِطَارِ", "The Cleaving", "Al-Infitaar", (byte)1, "سورة الانفطار", null, null, null, null, (short)19 },
                    { (short)83, (short)83, true, "سُورَةُ المُطَفِّفِينَ", "Defrauding", "Al-Mutaffifin", (byte)1, "سورة المطففين", null, null, null, null, (short)36 },
                    { (short)84, (short)84, true, "سُورَةُ الانشِقَاقِ", "The Splitting Open", "Al-Inshiqaaq", (byte)1, "سورة الانشقاق", null, null, null, null, (short)25 },
                    { (short)85, (short)85, true, "سُورَةُ البُرُوجِ", "The Constellations", "Al-Burooj", (byte)1, "سورة البروج", null, null, null, null, (short)22 },
                    { (short)86, (short)86, true, "سُورَةُ الطَّارِقِ", "The Morning Star", "At-Taariq", (byte)1, "سورة الطارق", null, null, null, null, (short)17 },
                    { (short)87, (short)87, true, "سُورَةُ الأَعۡلَىٰ", "The Most High", "Al-A'laa", (byte)1, "سورة الأعۡلىٰ", null, null, null, null, (short)19 },
                    { (short)88, (short)88, true, "سُورَةُ الغَاشِيَةِ", "The Overwhelming", "Al-Ghaashiya", (byte)1, "سورة الغاشية", null, null, null, null, (short)26 },
                    { (short)89, (short)89, true, "سُورَةُ الفَجۡرِ", "The Dawn", "Al-Fajr", (byte)1, "سورة الفجۡر", null, null, null, null, (short)30 },
                    { (short)90, (short)90, true, "سُورَةُ البَلَدِ", "The City", "Al-Balad", (byte)1, "سورة البلد", null, null, null, null, (short)20 },
                    { (short)91, (short)91, true, "سُورَةُ الشَّمۡسِ", "The Sun", "Ash-Shams", (byte)1, "سورة الشمۡس", null, null, null, null, (short)15 },
                    { (short)92, (short)92, true, "سُورَةُ اللَّيۡلِ", "The Night", "Al-Lail", (byte)1, "سورة الليۡل", null, null, null, null, (short)21 },
                    { (short)93, (short)93, true, "سُورَةُ الضُّحَىٰ", "The Morning Hours", "Ad-Dhuhaa", (byte)1, "سورة الضحىٰ", null, null, null, null, (short)11 },
                    { (short)94, (short)94, true, "سُورَةُ الشَّرۡحِ", "The Consolation", "Ash-Sharh", (byte)1, "سورة الشرۡح", null, null, null, null, (short)8 },
                    { (short)95, (short)95, true, "سُورَةُ التِّينِ", "The Fig", "At-Tin", (byte)1, "سورة التين", null, null, null, null, (short)8 },
                    { (short)96, (short)96, true, "سُورَةُ العَلَقِ", "The Clot", "Al-Alaq", (byte)1, "سورة العلق", null, null, null, null, (short)19 },
                    { (short)97, (short)97, true, "سُورَةُ القَدۡرِ", "The Power, Fate", "Al-Qadr", (byte)1, "سورة القدۡر", null, null, null, null, (short)5 },
                    { (short)98, (short)98, true, "سُورَةُ البَيِّنَةِ", "The Evidence", "Al-Bayyina", (byte)2, "سورة البينة", null, null, null, null, (short)8 },
                    { (short)99, (short)99, true, "سُورَةُ الزَّلۡزَلَةِ", "The Earthquake", "Az-Zalzala", (byte)2, "سورة الزلۡزلة", null, null, null, null, (short)8 },
                    { (short)100, (short)100, true, "سُورَةُ العَادِيَاتِ", "The Chargers", "Al-Aadiyaat", (byte)1, "سورة العاديات", null, null, null, null, (short)11 },
                    { (short)101, (short)101, true, "سُورَةُ القَارِعَةِ", "The Calamity", "Al-Qaari'a", (byte)1, "سورة القارعة", null, null, null, null, (short)11 },
                    { (short)102, (short)102, true, "سُورَةُ التَّكَاثُرِ", "Competition", "At-Takaathur", (byte)1, "سورة التكاثر", null, null, null, null, (short)8 },
                    { (short)103, (short)103, true, "سُورَةُ العَصۡرِ", "The Declining Day, Epoch", "Al-Asr", (byte)1, "سورة العصۡر", null, null, null, null, (short)3 },
                    { (short)104, (short)104, true, "سُورَةُ الهُمَزَةِ", "The Traducer", "Al-Humaza", (byte)1, "سورة الهمزة", null, null, null, null, (short)9 },
                    { (short)105, (short)105, true, "سُورَةُ الفِيلِ", "The Elephant", "Al-Fil", (byte)1, "سورة الفيل", null, null, null, null, (short)5 },
                    { (short)106, (short)106, true, "سُورَةُ قُرَيۡشٍ", "Quraysh", "Quraish", (byte)1, "سورة قريۡش", null, null, null, null, (short)4 },
                    { (short)107, (short)107, true, "سُورَةُ المَاعُونِ", "Almsgiving", "Al-Maa'un", (byte)1, "سورة الماعون", null, null, null, null, (short)7 },
                    { (short)108, (short)108, true, "سُورَةُ الكَوۡثَرِ", "Abundance", "Al-Kawthar", (byte)1, "سورة الكوۡثر", null, null, null, null, (short)3 },
                    { (short)109, (short)109, true, "سُورَةُ الكَافِرُونَ", "The Disbelievers", "Al-Kaafiroon", (byte)1, "سورة الكافرون", null, null, null, null, (short)6 },
                    { (short)110, (short)110, true, "سُورَةُ النَّصۡرِ", "Divine Support", "An-Nasr", (byte)2, "سورة النصۡر", null, null, null, null, (short)3 },
                    { (short)111, (short)111, true, "سُورَةُ المَسَدِ", "The Palm Fibre", "Al-Masad", (byte)1, "سورة المسد", null, null, null, null, (short)5 },
                    { (short)112, (short)112, true, "سُورَةُ الإِخۡلَاصِ", "Sincerity", "Al-Ikhlaas", (byte)1, "سورة الإخۡلاص", null, null, null, null, (short)4 },
                    { (short)113, (short)113, true, "سُورَةُ الفَلَقِ", "The Dawn", "Al-Falaq", (byte)1, "سورة الفلق", null, null, null, null, (short)5 },
                    { (short)114, (short)114, true, "سُورَةُ النَّاسِ", "Mankind", "An-Naas", (byte)1, "سورة الناس", null, null, null, null, (short)6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRefreshTokens_AdminUserId",
                table: "AdminRefreshTokens",
                column: "AdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminRefreshTokens_TokenHash",
                table: "AdminRefreshTokens",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_Email",
                table: "AdminUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AudioTracks_QiraaId",
                table: "AudioTracks",
                column: "QiraaId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioTracks_SheikhId_SurahId_QiraaId",
                table: "AudioTracks",
                columns: new[] { "SheikhId", "SurahId", "QiraaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AudioTracks_Status",
                table: "AudioTracks",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AudioTracks_SurahId",
                table: "AudioTracks",
                column: "SurahId");

            migrationBuilder.CreateIndex(
                name: "IX_AyahTimings_AudioTrackId_AyahId",
                table: "AyahTimings",
                columns: new[] { "AudioTrackId", "AyahId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AyahTimings_AyahId",
                table: "AyahTimings",
                column: "AyahId");

            migrationBuilder.CreateIndex(
                name: "IX_Ayat_SurahId_AyahNumber",
                table: "Ayat",
                columns: new[] { "SurahId", "AyahNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Qiraat_Slug",
                table: "Qiraat",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheikhEducationEntries_SheikhId",
                table: "SheikhEducationEntries",
                column: "SheikhId");

            migrationBuilder.CreateIndex(
                name: "IX_SheikhExperienceEntries_SheikhId",
                table: "SheikhExperienceEntries",
                column: "SheikhId");

            migrationBuilder.CreateIndex(
                name: "IX_SheikhHighlightCards_SheikhId",
                table: "SheikhHighlightCards",
                column: "SheikhId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheikhs_Slug",
                table: "Sheikhs",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SheikhTeachers_SheikhId",
                table: "SheikhTeachers",
                column: "SheikhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRefreshTokens");

            migrationBuilder.DropTable(
                name: "AyahTimings");

            migrationBuilder.DropTable(
                name: "FeaturedContents");

            migrationBuilder.DropTable(
                name: "MediaAssets");

            migrationBuilder.DropTable(
                name: "SheikhEducationEntries");

            migrationBuilder.DropTable(
                name: "SheikhExperienceEntries");

            migrationBuilder.DropTable(
                name: "SheikhHighlightCards");

            migrationBuilder.DropTable(
                name: "SheikhTeachers");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "AudioTracks");

            migrationBuilder.DropTable(
                name: "Ayat");

            migrationBuilder.DropTable(
                name: "Qiraat");

            migrationBuilder.DropTable(
                name: "Sheikhs");

            migrationBuilder.DropTable(
                name: "Surahs");
        }
    }
}
