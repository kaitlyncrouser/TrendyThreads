using System;
using System.Collections.Generic;

namespace TrendyThreads.Models;

public partial class CartClothing
{
    public long CartClothingId { get; set; }

    public long CartId { get; set; }

    public long ClothingId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Clothing Clothing { get; set; } = null!;
}
