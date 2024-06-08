namespace DLayer.Models;

public partial class TPreference
{
    public long Id { get; set; }

    public string Uta { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Book { get; set; }

    public string? Era { get; set; }

    public string? Index { get; set; }

    public string? Memo { get; set; }

    public string? CreateDate { get; set; }

    public string? UpdateDate { get; set; }
}
