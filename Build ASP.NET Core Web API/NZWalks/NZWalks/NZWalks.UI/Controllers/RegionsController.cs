﻿using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models;
using NZWalks.UI.Models.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClient httpClient;

        public RegionsController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();
            try
            {
                // Get All Regions From API
                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7143/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var content = new StringContent(
            JsonSerializer.Serialize(model),
            Encoding.UTF8,
            "application/json");

            var response = await httpClient.PostAsync("https://localhost:7143/api/regions", content);

            if (response.IsSuccessStatusCode)
            {
                // Handle success
                Console.WriteLine("Data sent successfully.");
            }
            else
            {
                // Handle error
                Console.WriteLine($"Failed to send data. Status code: {response.StatusCode}");
            }

            if (response is not null)
            {
                return RedirectToAction("Index", "Regions");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7143/api/regions/{id.ToString()}");

            if(response is not null)
            {
                return View(response);
            }

            return View(null);
        }
    }
}