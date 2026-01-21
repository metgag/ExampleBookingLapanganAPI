using BookingVenueApi.DTOs;
using BookingVenueApi.Models;

using Microsoft.AspNetCore.Mvc;

namespace BookingVenueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetJadwal([FromQuery] DateTime date)
        {
            var lapangan = new List<Lapangan>
            {
                new Lapangan { Id = 1, Nama = "ASATU Mini Soccer", JenisOlahraga = "Mini Soccer" }
            };
            var hargaLapangan = new List<HargaLapangan>
            {
                new HargaLapangan
                {
                    Id = 1,
                    LapanganId = 1,
                    DayTypeId = 1,
                    JamAwal = new TimeSpan(7,0,0),
                    JamAkhir = new TimeSpan(22,0,0),
                    IntervalMenit = 60,
                    Harga = 1650000
                },
                new HargaLapangan
                {
                    Id = 2,
                    LapanganId = 1,
                    DayTypeId = 2,
                    JamAwal = new TimeSpan(9,0,0),
                    JamAkhir = new TimeSpan(24,0,0),
                    IntervalMenit = 60,
                    Harga = 2050000
                }
            };
            var dayTypeId = (date.DayOfWeek == DayOfWeek.Saturday ||
                            date.DayOfWeek == DayOfWeek.Sunday)
                            ? 2 : 1;
            var result = new List<JadwalLapanganResponse>();

            foreach (var h in hargaLapangan.Where(x => x.DayTypeId == dayTypeId))
            {
                var lap = lapangan.First(l => l.Id == h.LapanganId);
                var jam = h.JamAwal;

                while (jam < h.JamAkhir)
                {
                    result.Add(new JadwalLapanganResponse
                    {
                        NamaLapangan = lap.Nama,
                        JenisOlahraga = lap.JenisOlahraga,
                        Jam = $"{jam:hh\\:mm} - {jam.Add(TimeSpan.FromMinutes(h.IntervalMenit)):hh\\:mm}",
                        Harga = h.Harga,
                    });

                    jam = jam.Add(TimeSpan.FromMinutes(h.IntervalMenit));
                }
            }

            return Ok(result);
        }
    }
}
