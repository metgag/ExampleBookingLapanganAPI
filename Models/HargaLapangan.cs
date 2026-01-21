namespace BookingVenueApi.Models;

public class HargaLapangan
{
    public int Id { get; set; }
    public int LapanganId { get; set; }

    public int DayTypeId { get; set; }
    // 2 weekend, 1 weekday

    public TimeSpan JamAwal { get; set; }
    public TimeSpan JamAkhir { get; set; }

    public decimal Harga { get; set; }
    public int IntervalMenit { get; set; }

    public int? PeriodeId { get; set; }
}
