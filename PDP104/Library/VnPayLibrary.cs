using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PDP104.Library
{
    public class VnPayLibrary
    {
        private readonly SortedList<string, string> _requestData = new();

        public void AddRequestData(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
                _requestData[key] = value;
        }

        public string CreateRequestUrl(string baseUrl, string hashSecret)
        {
            // ✅ Dùng ORDER BY để tạo SignData
            string signData = string.Join("&", _requestData
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => $"{kvp.Key}={kvp.Value}"));

            Console.WriteLine("🔍 SignData = " + signData);

            string secureHash = ComputeHash(hashSecret, signData);
            Console.WriteLine("🔐 SecureHash = " + secureHash);

            // ✅ Encode URL theo chuẩn và thứ tự giống y chang như signData
            var query = string.Join("&", _requestData
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => $"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value).Replace("+", "%20")}")
            );

            return $"{baseUrl}?{query}&vnp_SecureHash={secureHash}";
        }






        public bool ValidateSignature(IQueryCollection query, string hashSecret)
        {
            var data = query
                .Where(kvp => kvp.Key.StartsWith("vnp_") && kvp.Key != "vnp_SecureHash")
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());

            var signData = string.Join("&", data.OrderBy(k => k.Key).Select(kvp => $"{kvp.Key}={kvp.Value}"));
            string checkHash = ComputeHash(hashSecret, signData);

            return checkHash.Equals(query["vnp_SecureHash"], StringComparison.OrdinalIgnoreCase);
        }

        private string ComputeHash(string key, string data)
        {
            var encoding = new UTF8Encoding(false); // KHÔNG BOM
            var hmac = new HMACSHA512(encoding.GetBytes(key));
            var normalizedData = data.Normalize(NormalizationForm.FormC); // chuẩn Unicode
            byte[] hashValue = hmac.ComputeHash(encoding.GetBytes(normalizedData));
            return BitConverter.ToString(hashValue).Replace("-", "").ToUpper();
        }



    }

}
