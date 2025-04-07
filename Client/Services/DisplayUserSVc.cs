public static class UserNameExtensions
{
    public static async Task<string> GetUserNameAsync(this string userId, AccountsService accountService)
    {
        if (string.IsNullOrEmpty(userId)) return "Không xác định";

        var name = await accountService.GetUserNameAsync(userId);
        return name ?? "Không tìm thấy";
    }
}
