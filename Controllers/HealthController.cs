using Livre.configurations;
using Livre.models;
using Livre.models.requests;
using Livre.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livre.controllers {

    [ApiController]
    public class HealthController: ControllerBase {

        [HttpGet("health", Name = "GetHealth")]
        public string GetHealth() {
            return "UP";
        }

    }

}