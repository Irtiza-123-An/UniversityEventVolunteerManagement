using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace UniversityEventVolunteerManagement.Backend.Data
{
    public class JsonDataService<T> where T : class
    {
        private readonly string _dataDirectory;
        private readonly string _fileName;
        private readonly string _filePath;

        public JsonDataService(string fileName)
        {
            // Get the application base directory
            _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            _fileName = fileName;
            _filePath = Path.Combine(_dataDirectory, _fileName);

            // Ensure the data directory exists
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }

            // Initialize file if it doesn't exist
            if (!File.Exists(_filePath))
            {
                SaveData(new List<T>());
            }
        }

        public List<T> LoadData()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<T>();
                }

                string jsonString = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    return new List<T>();
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                return JsonSerializer.Deserialize<List<T>>(jsonString, options) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from {_fileName}: {ex.Message}");
                return new List<T>();
            }
        }

        public void SaveData(List<T> data)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {_fileName}: {ex.Message}");
                throw;
            }
        }

        public async Task SaveDataAsync(List<T> data)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonString = JsonSerializer.Serialize(data, options);
                await File.WriteAllTextAsync(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {_fileName}: {ex.Message}");
                throw;
            }
        }

        public string GetFilePath()
        {
            return _filePath;
        }
    }
}
