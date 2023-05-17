using System;
using System.Collections.Generic;

namespace TrendyThreads.Models;

public partial class ClothingColor
{
    public long ClothingColorId { get; set; }

    public string Color { get; set; } = null!;

    public virtual ICollection<Clothing> Clothings { get; set; } = new List<Clothing>();
}
