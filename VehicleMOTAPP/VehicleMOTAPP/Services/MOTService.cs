using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using VehicleMOTAPP.Models;

namespace VehicleMOTAPP.Services
{
    public class MOTService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "fZi8YcjrZN1cGkQeZP7Uaa4rTxua8HovaswPuIno";

        public MOTService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(Vehicle vehicle, string errorMessage)> GetVehicleDetails(string registration)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration={registration}");
                request.Headers.Add("x-api-key", ApiKey);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var vehicleList = await response.Content.ReadFromJsonAsync<List<Vehicle>>();
                    var vehicle = vehicleList?.FirstOrDefault();

                    if (vehicle == null)
                    {
                        return (null, "No data found for the provided registration number.");
                    }
                    return (vehicle, null);
                }
                else
                {
                    return (null, $"Error: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                return (null, $"Request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (null, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
