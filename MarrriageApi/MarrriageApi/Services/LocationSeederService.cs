using Marriage.Core.Entity;
using Marriage.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

public class LocationSeederService
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _context;

    public LocationSeederService(HttpClient httpClient, ApplicationDbContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    public async Task SeedAllLocationsAsync()
    {
        await SeedDivisionsAsync();
        await SeedDistrictsAsync();
        await SeedUpazilasAsync();
        await SeedUnionsAsync();

        Console.WriteLine("All locations seeded successfully ✅");
    }

    private async Task SeedDivisionsAsync()
    {
        var res = await _httpClient.GetStringAsync("https://bdapis.vercel.app/geo/v2.0/divisions");
        var data = JsonSerializer.Deserialize<ApiResponse<DivisionDto>>(res);

        using var tran = await _context.Database.BeginTransactionAsync();
        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Divisions ON");

        foreach (var d in data.Data)
        {
            if (!await _context.Divisions.AnyAsync(x => Convert.ToInt32(x.Id) == Convert.ToInt32(d.Id)))
            {
                _context.Divisions.Add(new Division { Id = Convert.ToInt32(d.Id), Name = d.Name });
            }
        }

        await _context.SaveChangesAsync();
        await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Divisions OFF");
        await tran.CommitAsync();
    }

    private async Task SeedDistrictsAsync()
    {
        var divisions = await _context.Divisions.ToListAsync();
        foreach (var div in divisions)
        {
            var res = await _httpClient.GetStringAsync($"https://bdapis.vercel.app/geo/v2.0/districts/{div.Id}");
            var data = JsonSerializer.Deserialize<ApiResponse<DistrictDto>>(res);

            using var tran = await _context.Database.BeginTransactionAsync();
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Districts ON");

            foreach (var d in data.Data)
            {
                if (!await _context.Districts.AnyAsync(x => Convert.ToInt32(x.Id) == Convert.ToInt32(d.Id)))
                {
                    _context.Districts.Add(new District
                    {
                        Id = Convert.ToInt32(d.Id),
                        Name = d.Name,
                        DivisionId = div.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Districts OFF");
            await tran.CommitAsync();
        }
    }

    private async Task SeedUpazilasAsync()
    {
        var districts = await _context.Districts.ToListAsync();
        foreach (var dist in districts)
        {
            var res = await _httpClient.GetStringAsync($"https://bdapis.vercel.app/geo/v2.0/upazilas/{dist.Id}");
            var data = JsonSerializer.Deserialize<ApiResponse<UpazilaDto>>(res);

            using var tran = await _context.Database.BeginTransactionAsync();
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Upazilas ON");

            foreach (var u in data.Data)
            {
                if (!await _context.Upazilas.AnyAsync(x => Convert.ToInt32(x.Id) == Convert.ToInt32(u.Id)))
                {
                    _context.Upazilas.Add(new Upazila
                    {
                        Id = Convert.ToInt32(u.Id),
                        Name = u.Name,
                        DistrictId = dist.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Upazilas OFF");
            await tran.CommitAsync();
        }
    }

    private async Task SeedUnionsAsync()
    {
        var upazilas = await _context.Upazilas.ToListAsync();
        foreach (var up in upazilas)
        {
            var res = await _httpClient.GetStringAsync($"https://bdapis.vercel.app/geo/v2.0/unions/{up.Id}");
            var data = JsonSerializer.Deserialize<ApiResponse<UnionDto>>(res);

            using var tran = await _context.Database.BeginTransactionAsync();
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Unions ON");

            foreach (var u in data.Data)
            {
                if (!await _context.Unions.AnyAsync(x => Convert.ToInt32( x.Id) == Convert.ToInt32(u.Id)))
                {
                    _context.Unions.Add(new Union
                    {
                        Id = Convert.ToInt32(u.Id),
                        Name = u.Name,
                        UpazilaId = up.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Unions OFF");
            await tran.CommitAsync();
        }
    }
}

// ---------------- DTOs ----------------
public class ApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("data")]
    public List<T> Data { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }
}

public class DivisionDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }   // API sends string

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("bn_name")]
    public string BnName { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
public class DistrictDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }   // API sends string

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("bn_name")]
    public string BnName { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
public class UpazilaDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }   // API sends string

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("bn_name")]
    public string BnName { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
public class UnionDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }   // API sends string

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("bn_name")]
    public string BnName { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
