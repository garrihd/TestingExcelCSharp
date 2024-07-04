using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using System.Text;


public class TicketOwnerChecker
{

    static async Task Main(string[] args)
    {
        string ticketNumber = "INC31795967";

        // Instantiate TicketOwnerChecker
        TicketOwnerChecker ownerChecker = new TicketOwnerChecker();

        // Call CheckOwner method and await its result
        string assignedTo = await ownerChecker.CheckOwner(ticketNumber);

        if (assignedTo != null)
        {
            Console.WriteLine($"Assigned to: {assignedTo}");
        }
        else
        {
            Console.WriteLine("Failed to retrieve owner information.");
        }
    }

    private readonly HttpClient _client = new HttpClient();
    private readonly string _snowUser = "userpad1";
    private readonly string _snowPass = ",EGHc?crKju3hz0),n{T)zRDXr5nr80I";
    // private readonly string _apiHeaders = "api_headers";

    public async Task<string> CheckOwner(string ticketNumber)
    {
        string link = $"https://api.glb.platform.dxc.com/inc1-api/dxc/incident/R2/incidents/{ticketNumber}";
        // Create HttpRequestMessage with headers
        var request = new HttpRequestMessage(HttpMethod.Get, link);
        request.Headers.Add("x-dxc-inf-user", "Palbot");
        request.Headers.Add("Accept-Encoding", "gzip");
        request.Headers.Add("x-dxc-inf-route-key", "serviceNow");
        string authInfo = $"{_snowUser}:{_snowPass}";
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo)));

        // Send the request
        HttpResponseMessage response = await _client.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            int statusCode = (int)response.StatusCode;
            Console.WriteLine($"Failed to retrieve data. Status code: {statusCode}");
            return null;
        }

        string responseJson = await response.Content.ReadAsStringAsync();
        dynamic responseObj = JsonSerializer.Deserialize<dynamic>(responseJson);

        string assignedTo = responseObj["assignedToPerson"];
        return assignedTo;
    }
}
