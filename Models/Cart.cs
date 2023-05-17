using System;
using System.Collections.Generic;

namespace TrendyThreads.Models;

public partial class Cart
{
    public long CartId { get; set; }

    public long? UserId { get; set; }

    public virtual ICollection<CartClothing> CartClothings { get; set; } = new List<CartClothing>();

    public virtual User? User { get; set; }
}
