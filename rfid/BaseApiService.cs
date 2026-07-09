using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
using rfid.utils;

public class BaseApiService<T>
{


    private readonly HttpClient _http;
    private readonly string _baseUrl;
    public BaseApiService(string baseUrl)
    {
        var handler = new HttpClientHandler()
        {
            UseProxy = false // <--- Desactiva el proxy
        };

        _baseUrl = baseUrl;
        _http = new HttpClient(handler);
    }

    // GET: obtener lista
    public async Task<List<T>> GetAllAsync()
    {
        var response = await _http.GetAsync(_baseUrl);
        var json = await response.Content.ReadAsStringAsync();

        //Console.WriteLine("Respuesta de API_GetAllAsync:");
        //Console.WriteLine(json);

        return JsonConvert.DeserializeObject<List<T>>(json);
    }

    //GET: BY
    public async Task<List<T>> GetByIdAsync(int id)
    {
        var r = await _http.GetAsync($"{_baseUrl}?id={id}");
        var json = await r.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<T>>(json);
    }


    // POST: crear
    public async Task<ApiResponse> CreateAsync<TIn>(TIn data)
    {
        string json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync(_baseUrl, content);

        return new ApiResponse
        {
            Success = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            Content = await response.Content.ReadAsStringAsync()
        };
    }

    // PUT: actualizar
    public async Task<bool> UpdateAsync<TIn>(TIn data)
    {
        string json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _http.PutAsync(_baseUrl, content);
        return response.IsSuccessStatusCode;
    }

    // DELETE: eliminar
    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}?id={id}");
        
        return response.IsSuccessStatusCode;
    }

}
