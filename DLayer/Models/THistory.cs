using System;
using System.Collections.Generic;

namespace DLayer.Models;

public partial class THistory
{
    public long Id { get; set; }

    public long? ShortSong { get; set; }

    public string? Before { get; set; }

    public string? Comment { get; set; }
}
