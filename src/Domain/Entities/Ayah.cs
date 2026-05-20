namespace HassanAdly.Domain.Entities;

public class Ayah : BaseAuditableEntity<long>
{
    public required short SurahId { get; set; }
    public required short AyahNumber { get; set; }
    public int? GlobalAyahNumber { get; set; }
    public required string TextUthmani { get; set; }
    public byte Juz { get; set; }
    public byte Hizb { get; set; }
    public short PageNumber { get; set; }
    public byte? RubElHizb { get; set; }
    public string? SajdahType { get; set; }

    public Surah? Surah { get; set; }
    public ICollection<AyahTiming> Timings { get; set; } = new List<AyahTiming>();
}
