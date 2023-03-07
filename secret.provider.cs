﻿namespace DockerSecret;

public class SecretProvider
{
    private string? _location;

    public async Task<string> Get(string name) {
        return await this.Get<string>(name);
    }
    public async Task<T> Get<T>(string name) {

        var location = _location ?? "/run/secrets";
        string value =  (await System.IO.File.ReadAllTextAsync(_location + "/" + name)).Trim();
        return (T) Convert.ChangeType(value, typeof(T));
    }

    public string GetLocation() {
        return this._location ?? "/run/secrets";
    }

    public SecretProvider(string? location = null) {
        this._location = location;
    }
}