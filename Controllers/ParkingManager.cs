using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserPrivileges.Models.DTOs;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParkingManager  :  ControllerBase
    {

        private readonly IParkingManagerRepository _parkingmanagerrepository;
        private readonly IMapper _mapper;

        public ParkingManager(IParkingManagerRepository parkingmanagerrepository, IMapper mapper)
        {
            _parkingmanagerrepository = parkingmanagerrepository;
            _mapper = mapper;
        }

        [HttpPost]
        //E=>Time you Entered parking lot, L=>Time you Left parking Lot
        public IActionResult Solution(string E, string L)
        {
            try
            {

                var getCalculatedFee = _parkingmanagerrepository.Solution(E, L);
                return Ok(getCalculatedFee);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetPackingTickets(string dayDate)
        {

            var tickets = _parkingmanagerrepository.GetParkingTickets(dayDate);

            var ticketsDto = new List<PackingTicketsDTO>();

            foreach (var ticket in tickets)
            {
                ticketsDto.Add(_mapper.Map<PackingTicketsDTO>(ticket));
            }

            return Ok(ticketsDto);
        }

    }
}
