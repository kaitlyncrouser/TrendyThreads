using System;
using System.Collections.Generic;

namespace TrendyThreads.Models;

public partial class ClothingType
{
    public long ClothingTypeId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Clothing> Clothings { get; set; } = new List<Clothing>();
}
