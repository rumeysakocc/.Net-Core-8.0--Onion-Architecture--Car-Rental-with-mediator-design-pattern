﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactsController(GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactQueryHandler = getContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("İletişim Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handler(new RemoveContactCommand(id));
            return Ok("İletişim Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handler(command);
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}
