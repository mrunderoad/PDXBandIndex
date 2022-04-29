using System.Collections.Generic;

namespace PDXBandIndex.Models
{
  public class Genre
  {
    public Genre()
    {
      this.JoinEntities = new HashSet<GenreBand>();
    } 

    public int GenreId { get; set; }
    public string GenreName { get; set; }
    public virtual ICollection<GenreBand> JoinEntities { get; set; }
  }
}