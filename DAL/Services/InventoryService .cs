using BLL.Interface;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Services
{
    using Microsoft.Extensions.Logging;

    public class InventoryService : IInventoryService
    {
        private readonly ISkladiste _skladisteRepo;
        private readonly IStavka _stavkaRepo;
        private readonly IRacun _racunaRepo;
        private readonly INormativi _normativiRepo;
        private readonly ILogger<InventoryService> _logger; // Dodano

        public InventoryService(
            ISkladiste skladisteRepo,
            IStavka stavkaRepo,
            IRacun racunaRepo,
            INormativi normativiRepo,
            ILogger<InventoryService> logger) // Dodano
        {
            _skladisteRepo = skladisteRepo;
            _stavkaRepo = stavkaRepo;
            _racunaRepo = racunaRepo;
            _normativiRepo = normativiRepo;
            _logger = logger; // Dodano
        }


        public double? CalculateDaysRemaining(int artikalId)
        {
            DateTime today = DateTime.Now;
            DateTime sevenDaysAgo = today.AddDays(-7);

            // Logiramo Artikal_Id za koji radimo izračun
            _logger.LogInformation($"Započinje izračun za Artikal_Id: {artikalId}");

            // Dobavi sve račune u zadnjih 7 dana
            var racuni = _racunaRepo.GetRacunFromDate(sevenDaysAgo, today);

            // Logiramo koliko je računa dohvaćeno
            _logger.LogInformation($"Dohvaćeno računa: {racuni.Count()} za Artikal_Id: {artikalId}");

            // Filtriraj stavke prema računima
            var totalConsumption = _stavkaRepo.GetAllStavka()
                .Where(s => s.Artikal_Id == artikalId &&
                            racuni.Any(r => r.Dokument_Id == s.Dokument_id))
                .Sum(s => s.Kolicina);

            _logger.LogInformation($"Ukupna potrošnja za Artikal_Id: {artikalId} iznosi {totalConsumption}.");

            if (totalConsumption == 0)
            {
                _logger.LogInformation($"Nema potrošnje za Artikal_Id: {artikalId}");
                return null;
            }

            // Dobavi sve normative za taj artikal
            var normativi = _normativiRepo.GetNormativByArticleId(artikalId);

            if (normativi == null || !normativi.Any())
            {
                _logger.LogError($"Nema normativa za Artikal_Id: {artikalId}");
                throw new InvalidOperationException("Normativ za ovaj artikal nije pronađen.");
            }

            double? minDaysRemaining = null;

            foreach (var normativ in normativi)
            {
                // Dobavi količinu u skladištu za taj normativni artikal
                var stockQuantity = _skladisteRepo.GetAllSkladiste()
                    .Where(s => s.Id == normativ.Skladiste_Id)
                    .Sum(s => s.Kolicina);

                _logger.LogInformation($"Za Artikal_Id {artikalId}, normativ: {normativ.Naziv}, zaliha u skladištu: {stockQuantity}.");

                if (stockQuantity == 0)
                {
                    _logger.LogInformation($"Nema zaliha za normativ: {normativ.Naziv} za Artikal_Id: {artikalId}");
                    return null;
                }

                double adjustedConsumption = totalConsumption * normativ.Normativ;
                double dailyConsumption = adjustedConsumption / 7.0;

                double daysRemaining = stockQuantity / dailyConsumption;

                _logger.LogInformation($"Potrošnja po danu za Artikal_Id {artikalId} iznosi {dailyConsumption}. Zaliha u skladištu: {stockQuantity}, prilagođena potrošnja: {adjustedConsumption}. Preostali dani: {daysRemaining}");

                // U ovom slučaju ne uzimamo minimum dana
                daysRemaining = Math.Round(daysRemaining);

                minDaysRemaining = daysRemaining;
            }

            _logger.LogInformation($"Izračun preostalih dana za Artikal_Id {artikalId}: {minDaysRemaining} dana.");

            return minDaysRemaining;
        }



        // Funkcija za računanje preostalih dana za sve artikle
        public List<ArtikalDaysRemaining> CalculateDaysRemainingForAll()
        {
            var results = new List<ArtikalDaysRemaining>();

            // Dohvati sve artikle iz skladišta
            var allSkladisteArtikli = _skladisteRepo.GetAllSkladiste().ToList();

            foreach (var skladisteArtikal in allSkladisteArtikli)
            {
                // Računamo preostale dane za svaki artikal koristeći njegov Artikal_Id
                double? daysRemaining = CalculateDaysRemaining(skladisteArtikal.Id);

                results.Add(new ArtikalDaysRemaining
                {
                    ArtikalId = skladisteArtikal.Id,
                    ArtikalNaziv = skladisteArtikal.Artikal,
                    DaysRemainingText = daysRemaining.HasValue ? daysRemaining.Value.ToString() : "N/A"
                });
            }

            return results;
        }
    }
}
