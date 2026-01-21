namespace BookingVenueApi.DTOs;

public class JadwalLapanganResponse
{
    public string NamaLapangan { get; set; } = null!;
    public string JenisOlahraga { get; set; } = null!;
    public string Jam { get; set; } = null!;
    public decimal Harga { get; set; }
}
