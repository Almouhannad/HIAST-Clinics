using Domain.Entities.Medicals.Medicines;
using Domain.Errors;
using Domain.Shared;
using MedicinesAPI.Configuration;
using MedicinesAPI.Contrants;
using System.Text.Json;

namespace MedicinesAPI.Services;

public class MedicinesAPIServices : IMedicinesAPIServices
{
    #region Http client DI 
    private readonly HttpClient _httpClient;

    public MedicinesAPIServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    #endregion

    public async Task<Result<ICollection<Medicine>>> GetAll()
    {
        try
        {
            // Get response
            var response = await _httpClient.GetAsync(APILink.Link);
            response.EnsureSuccessStatusCode();

            // Parse response
            var responseBody = await response.Content.ReadAsStringAsync();
            var medicineResponses = JsonSerializer.Deserialize<MedicineResponse[]>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true } // id in Json, Id in contract class
                );

            List<Medicine> medicines = new();
            if (medicineResponses is not null)
            {
                foreach (var medicineResponse in medicineResponses)
                {
                    Result<Medicine> medicineResult = medicineResponse.GetMedicine();
                    if (medicineResult.IsFailure)
                        return Result.Failure<ICollection<Medicine>>(medicineResult.Error);
                    medicines.Add(medicineResult.Value);
                }
                return medicines;
            }
            else
            {
                return Result.Failure<ICollection<Medicine>>(APIErrors.NoData);
            }

        }
        catch (Exception)
        {
            return Result.Failure<ICollection<Medicine>>(APIErrors.UnableToConnect);
        }
    }
}
