using Client.Models.AuthenViewModel;

public class AccountsService
{
    private readonly HttpClient _httpClient;

    public AccountsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var response = await _httpClient.GetAsync($"Users/{userId}/name");
        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadFromJsonAsync<UserNameResponse>();
        return content?.UserName;
    }

    internal async Task RegisterAsync(RegisterViewModel model)
    {
        throw new NotImplementedException();
    }

    private class UserNameResponse
    {
        public string UserName { get; set; } = string.Empty;
    }
}
