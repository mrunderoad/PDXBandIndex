using System.Collections.Generic;
using System.Linq;
using System;

namespace PDXBandIndex.Models
{
  public class Show
  {
    public Show()
    {
      this.JoinEntities = new HashSet<BandShow>();
    }

    public int ShowId { get; set; }
    public string Venue { get; set; }
    public DateTime Date { get; set; }
    public string Info { get; set; }
    public string Time { get; set; }
    public string Flyer { get; set; }
    public bool Favorite { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<BandShow> JoinEntities { get; set; }
  }
}