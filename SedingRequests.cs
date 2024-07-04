// using System.Net.Http;
// using System.Text.RegularExpressions;
// using Newtonsoft.Json.Linq;


// public class TicketUpdater
// {
//     private static readonly HttpClient client = new HttpClient();
//     private static readonly string pagApiSnowUser = "your_username";
//     private static readonly string pagApiSnowPass = "your_password";
//     private static readonly string apiHeaders = "your_api_headers";

//     public async Task UpdateTicket(dynamic email, string incidentNumber)
//     {
//         string snowUser = pagApiSnowUser;
//         string snowPass = pagApiSnowPass;
//         string headers = apiHeaders;

//         string updateLink = $"https://api.glb.platform.dxc.com/inc1-api/dxc/incident/R2/incidents/{incidentNumber}";
        
//         HttpResponseMessage response = await client.GetAsync(updateLink);
//         response.EnsureSuccessStatusCode();
//         string responseJson = await response.Content.ReadAsStringAsync();
//         dynamic responseObject = JObject.Parse(responseJson);
//         dynamic workNotes = responseObject.workNotes;
//         // string pattern = Regex.Match(email.Body, @"[\s\S]*?(?=From:|Von:|De:|От:)");

//         string textOfUpdate = TextToUpdate(email);
//         string shortDescription = responseObject.shortDescription;
//     }

//     private string TextToUpdate(dynamic email)
//     {
//         // Your logic for extracting text from email
//         // Example: return email.Body;
//         return "true";
//     }
// }
