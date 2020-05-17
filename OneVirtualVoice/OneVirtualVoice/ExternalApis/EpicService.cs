using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using OneVirtualVoice.Models;

namespace OneVirtualVoice.ExternalApis
{
    public class EpicService
    {
        private readonly string _endpoint = "https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/";
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public Patient GetPatient(string id)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            
            var patientResponse = client.DownloadString($"{_endpoint}/patient/{id}");
            
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            var allergiesResponse = client.DownloadString($"{_endpoint}/AllergyIntolerance?patient={id}");

            client.Headers[HttpRequestHeader.Accept] = "application/json";
            var vitalSignsResponse = client.DownloadString($"{_endpoint}/Observation/?patient={id}&category=vital-signs");
            
            client.Headers[HttpRequestHeader.Accept] = "application/json";
            //var imagingResponse = client.DownloadString($"{_endpoint}/Observation/?patient={id}&category=imaging");


            var patient = JsonSerializer.Deserialize<Patient>(patientResponse, _jsonOptions);
            var allergies = JsonSerializer.Deserialize<Allergy>(allergiesResponse, _jsonOptions);
            var vitalSigns = JsonSerializer.Deserialize<Observations>(vitalSignsResponse, _jsonOptions);
            //var imaging = JsonSerializer.Deserialize<Observations>(imagingResponse, _jsonOptions);
            
            patient.Allergies = allergies;
            patient.VitalSigns = vitalSigns;
            //patient.Imaging = imaging;

            return patient;
        }
    }
}