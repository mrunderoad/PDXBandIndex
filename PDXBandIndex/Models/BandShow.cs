namespace PDXBandIndex.Models
{
  public class BandShow
  {
    public int BandShowId { get; set; }
    public int BandId { get; set; }
    public int ShowId { get; set; }
    public virtual Band Band { get; set; }
    public virtual Show Show { get; set; }
  }
}