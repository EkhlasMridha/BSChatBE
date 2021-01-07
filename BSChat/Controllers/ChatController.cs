using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSChatService.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Models.DTO;
using Models.Entities;
using AutoMapper;
using DataManager.Contracts;
using BSChat.Constants;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSChat.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private IHubContext<BSChatBaseHub,IMessageHandler> _baseHub;
        private IMapper _mapper;
        private IChatManager _chatManager;
        public ChatController(IHubContext<BSChatBaseHub, IMessageHandler> baseHub, IMapper mapper, IChatManager chatManager)
        {
            _baseHub = baseHub;
            _mapper = mapper;
            _chatManager = chatManager;
        }
        // GET: v1/<ChatController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {  
            return Ok();
        }

        [HttpPost("text")]
        public async Task<IActionResult> SendMessageToExisting([FromBody] MessageGroup textMessage)
        {
            var message = textMessage.TextMessages.First();
            message.SentTime = DateTime.Now;

            var result = await _chatManager.StoreInExistingGroup(message);
            textMessage.TextMessages.Add(result);
            await _baseHub.Clients.User(textMessage.SenderId.ToString()).RecieveMessageAsync(textMessage);
            await _baseHub.Clients.User(textMessage.ReceiverId.ToString()).RecieveMessageAsync(textMessage);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGroup([FromBody] MessageGroup messageGroup)
        {
            var hasGroup = await _chatManager.HasMessageGroup(messageGroup.SenderId, messageGroup.ReceiverId);
            if (hasGroup)
            {
                return BadRequest("GROUP_EXIST");
            }
            var group = await _chatManager.CreateNewGroup(messageGroup);
            return Ok(group);
        }

        [HttpGet("old")]
        public async Task<IActionResult> GetOldMessages()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userID = identity.FindFirst(BSConstants.UserId)?.Value;
            int id = Int32.Parse(userID);

            var result = await _chatManager.GetOldMessages(id);

            return Ok(result);
        }

        [HttpGet("group/{friendId}")]
        public async Task<IActionResult> GetGroup(int friendId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string userID = identity.FindFirst(BSConstants.UserId)?.Value;
            int id = Int32.Parse(userID);

            var result = await _chatManager.GetMessageGroup(friendId, id);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task DeleteGroup(MessageGroup messageGroup)
        {
           await _chatManager.DeleteMessage(messageGroup);
        }
    }
}
