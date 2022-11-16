using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serve.Core.Models;
using Serve.Domain.DataTransferObjects;
using Serve.Domain.LogicInterfaces;

namespace Serve.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        //private IMailService _mailService;
        //IMailService mailService
        public AppointmentController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            //_mailService = mailService;

        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForCreationDto appointment)
        {
            try
            {
                //var appointment = _repository.Appointment.GetAppointment(id, trackChanges: false);

                //return Ok(appointmentDto);
                if (appointment == null)
                {
                    return BadRequest("appointmentDto object is null");
                }
                else
                {
                    // mapping dto app to DB appointment, Dto appointment is parsed as parameter when consuming api
                    //var dbappointment = new Appointment();
                    //dbappointment.Id = appointment.Id;
                    //dbappointment.AppointmentTitle = appointment.AppointmentTitle;
                    //dbappointment.Url = appointment.Url;
                    //dbappointment.Address = appointment.Address;
                    //dbappointment.State = appointment.State;
                    var appointmentEntity = _mapper.Map<Appointment>(appointment);

                    _repository.Appointment.CreateAppointment(appointmentEntity);
                    //_repository.Appointment.CreateAppointment(dbappointment);
                    _repository.Save();


                    var appointmentCreated = _mapper.Map<AppointmentDto>(appointmentEntity);
                    return Ok("Appointment Created");

                    //send email notification
                    //await _mailService.SendEmailAsync(appointment.Url, "Serve", EmailFormatter.TeamMemberInvitation(model.Email, model.TeamName));
                    //return Ok(new Response { Status = "Success", Message = "Member Invited successfully!" });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error ");
            }
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {

            try
            {
                var appointments = _repository.Appointment.GetAllAppointments();
                //return Ok(appointments);
                //var ap = new Appointment();
                //ap.AppointmentTitle.Any(w => w.Equals. );
                //ap.Appointment.Where(m => !m.EmployeeName.Contains("%[0-9]%")

                //var status = Appointment.AppointmentStatus.Where(m => AppointmentStatus.Contains("pending"));
                var appointmentDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

                return Ok(appointmentDto);
            //var appointmentDto = appointments.Select(c => new AppointmentDto
            //{
            //    Id = c.Id,
            //    //Name = c.Name,
            //    Url = c.Url,
            //    Address = string.Join(' ', c.Address, c.State)
            //}).ToList();
                return Ok(appointmentDto);
            }

                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error ");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAppointment(int id)
        {
            try
            {
                var appointment = _repository.Appointment.GetAppointment(id, trackChanges: false);
                if (appointment == null)
                {
                    return NotFound();
                }
                else
                {
                    var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
                    return Ok(appointmentDto);
                }
               
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] AppointmentForUpdateDto appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest("AppointmentDto object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid appointment model object sent from client.");
                }

                var appointmentEntity = _repository.Appointment.GetAppointment(id, trackChanges: true);
                if (appointmentEntity == null)
                {
                    return NotFound($"Appointment with id: {id} doesn't exist in the database.");
                }
                _mapper.Map(appointment, appointmentEntity);
                _repository.Appointment.UpdateAppointment(appointmentEntity);
                _repository.Save();
                return Ok("Apppoinment Updated");
                //return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside UpdateOwner action: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _repository.Appointment.GetAppointment(id, trackChanges: false);
            if (appointment == null)
            {
                return NotFound($"Appointment with id: { id} doesn't exist in the database.");
            }
            _repository.Appointment.DeleteAppointment(appointment);
            _repository.Save();
            return Ok("Appointment has been deleted");
            //return NoContent();
        }

        
    }
}
