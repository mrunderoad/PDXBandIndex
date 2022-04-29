namespace PDXBandIndex.Models
{
  public class GenreBand
  {
    public int GenreBandId { get; set; }
    public int BandId { get; set; }
    public int GenreId { get; set; }
    public virtual Band Band { get; set; }
    public virtual Genre Genre { get; set; }
  }
}