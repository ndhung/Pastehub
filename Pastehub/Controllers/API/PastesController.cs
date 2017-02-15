﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Pastehub.Helpers;
using Pastehub.Models;

namespace Pastehub.Controllers.API
{
    public class PastesController : ApiController
    {
        private PastehubRepository _repo;

        public PastesController()
        {
            _repo = new PastehubRepository();
        }

        [HttpGet]
        [Route("api/pastes")]
        public IHttpActionResult Get()
        {
            return Ok("Nothing to show");
        }

        [HttpPost]
        [Route("api/pastes")]
        public IHttpActionResult Post([FromBody]Paste newPaste)
        {
            try
            {
                try
                {
                    _repo.AddPaste(newPaste);
                    return Ok(newPaste);
                }
                catch (Exception exception)
                {
                    return BadRequest(exception.Message);
                }
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
    }
}
