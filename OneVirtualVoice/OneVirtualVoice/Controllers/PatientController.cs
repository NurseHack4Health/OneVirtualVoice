using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneVirtualVoice.ExternalApis;
using OneVirtualVoice.Models;

namespace OneVirtualVoice.Controllers
{
    [Route("patients")]
    public class PatientController : Controller
    {
        private readonly EpicService _epicService;
        
        public PatientController(EpicService epicService)
        {
            _epicService = epicService;
        }

        [HttpGet("")]
        public IActionResult List()
        {
            return View(Patient.AllPatients);
        }

        [HttpGet("{id}")]
        public IActionResult Show(string id)
        {
            var patient = _epicService.GetPatient(id);
            patient.VitalSigns.Entry = patient.VitalSigns.Entry.Where(e => e.Resource.Code != null).GroupBy(e => e.Resource.Code.Text)
                .SelectMany(g => g.OrderByDescending(i => i.Resource.EffectiveDateTime).Take(1)).ToArray();
            return View(patient);
        }
    }
}