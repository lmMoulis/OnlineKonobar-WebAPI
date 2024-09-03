using BLL.Interface;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IArtikal _artikalRepo;
        private readonly ISkladiste _skladisteRepo;
        private readonly IStavka _stavkaRepo;
        private readonly IRacun _racunaRepo;
        private readonly INormativi _normativiRepo;

        public InventoryService(
            IArtikal artikalRepo,
            ISkladiste skladisteRepo,
            IStavka stavkaRepo,
            IRacun racunaRepo,
            INormativi normativiRepo)
        {
            _artikalRepo = artikalRepo;
            _skladisteRepo = skladisteRepo;
            _stavkaRepo = stavkaRepo;
            _racunaRepo = racunaRepo;
            _normativiRepo = normativiRepo;
        }
        public double? CalculateDaysRemaining(int artikalId)
        {
            DateTime today = DateTime.Now;
            DateTime sevenDaysAgo = today.AddDays(-7);

            // Dobavi sve račune u zadnjih 7 dana
            var racuni = _racunaRepo.GetRacunFromDate(sevenDaysAgo, today);

            // Filtriraj stavke prema računima
            var totalConsumption = _stavkaRepo.GetAllStavka()
                .Where(s => s.Artikal_Id == artikalId &&
                            racuni.Any(r => r.Dokument_Id == s.Dokument_id))
                .Sum(s => s.Kolicina);

            if (totalConsumption == 0)
            {
                // Ako nema potrošnje, vraća null
                return null;
            }

            // Dobavi količinu u skladištu
            var artikal = _artikalRepo.GetArtikaldId(artikalId);
            if (artikal == null)
            {
                throw new InvalidOperationException("Artikal nije pronađen.");
            }

            var stockQuantity = _skladisteRepo.GetAllSkladiste()
                .Where(s => s.Artikal == artikal.Naziv)
                .Sum(s => s.Kolicina);

            if (stockQuantity == 0)
            {
                // Ako nema zaliha, vraća null
                return null;
            }

            // Dobavi normativ za taj artikal
            var normativ = _normativiRepo.GetNormativiByArticleId(artikalId);
            if (normativ == null)
            {
                throw new InvalidOperationException("Normativ za ovaj artikal nije pronađen.");
            }

            // Izračunaj prosječnu dnevnu potrošnju u skladu s normativom
            double dailyConsumption = (totalConsumption * normativ.Normativ) / 7.0;

            // Izračunaj koliko dana zalihe traju
            double daysRemaining = stockQuantity / dailyConsumption;

            // Zaokruži na cijeli broj
            return Math.Round(daysRemaining);
        }

        public List<ArtikalDaysRemaining> CalculateDaysRemainingForAll()
        {
            var results = new List<ArtikalDaysRemaining>();

            var allArtikli = _artikalRepo.GetAllArtikal();

            foreach (var artikal in allArtikli)
            {
                double? daysRemaining = CalculateDaysRemaining(artikal.Id);

                results.Add(new ArtikalDaysRemaining
                {
                    ArtikalId = artikal.Id,
                    ArtikalNaziv = artikal.Naziv,
                    DaysRemainingText = daysRemaining.HasValue ? Math.Round(daysRemaining.Value).ToString() : "N/A"
                });
            }

            return results;
        }


    }
}


