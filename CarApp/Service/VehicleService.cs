using CarApp.Models;

namespace CarApp.Service
{
    public class VehicleService
    {
        private readonly HttpClient _httpClient;

        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Make>> GetAllMakesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Make>>("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
            return response?.Results ?? Array.Empty<Make>();
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<VehicleType>>($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json");
            return response?.Results ?? Array.Empty<VehicleType>();
        }

        public async Task<IEnumerable<Model>> GetModelsForMakeAndYearAsync(int makeId, int year)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Model>>($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
            return response?.Results ?? Array.Empty<Model>();
        }

    }
}
