using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using CoraApp.Models;

namespace CoraApp.Services;

public class UserService
{
    private readonly List<User> _users = new();
    private readonly string _path;

    public UserService()
    {
        _path = Path.Combine(AppContext.BaseDirectory, "users.json");
        Load();
    }

    private void Load()
    {
        try
        {
            if (File.Exists(_path))
            {
                var json = File.ReadAllText(_path);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                if (users != null) _users.AddRange(users);
            }
        }
        catch { }
    }

    private void Save()
    {
        try
        {
            var json = JsonSerializer.Serialize(_users);
            File.WriteAllText(_path, json);
        }
        catch { }
    }

    public Task<bool> RegisterAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return Task.FromResult(false);

        if (_users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            return Task.FromResult(false);

        _users.Add(new User { Username = username, PasswordHash = Hash(password) });
        Save();
        return Task.FromResult(true);
    }

    public Task<bool> AuthenticateAsync(string username, string password)
    {
        var hash = Hash(password);
        var ok = _users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.PasswordHash == hash);
        return Task.FromResult(ok);
    }

    private static string Hash(string input)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input ?? string.Empty));
        return Convert.ToBase64String(bytes);
    }
}
