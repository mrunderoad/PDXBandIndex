using System.Collections.Generic;
using System.Linq;
using System;

namespace PDXBandIndex.Models
{
  public class Band
  {
    
    public Band()
    {
      this.JoinEntities = new HashSet<GenreBand>();
      this.JoinEntities2 = new HashSet<BandShow>();
    }

    public int BandId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Members { get; set; }
    public string Music { get; set; }
    public string Search { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<GenreBand> JoinEntities { get; }
    public virtual ICollection<BandShow> JoinEntities2 { get; }
  }
}