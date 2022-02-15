using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toyota.Data;
using Toyota.Data.Entities;

namespace Toyota.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreCallbackController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreCallbackController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        // POST: api/StoreCallback
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Callback>> PostCallback(Callback callback)
        {
            //callback.Photo = await Helpers.Media.UploadImage(fileToStorage, "callback_photo");
            _context.Callbacks.Add(callback);
            await _context.SaveChangesAsync();

            Helper.Notification.Telegram.SendMessage("Обрабатывайте парня => " + callback.Name + "\nНомер телефона => " + callback.Phone + "\nИдентификатор => " + callback.Id + "\n\nУ вас 3 месяца");
            await Helper.Notification.Email.SendEmailAsync(callback.Email, "Заявка", "Спасибо за отправку заявки, " + callback.Name + "!<br>Ожидайте ответа на ваш указанный номер => " + callback.Phone + "<br>Ваш уникальный индентификатор => " + callback.Id + "<br><br>Ответ будет в течении 1 часа");

            
            return CreatedAtAction("GetCallback", new { id = callback.Id }, callback);
        }

       

        private bool CallbackExists(Guid id)
        {
            return _context.Callbacks.Any(e => e.Id == id);
        }
    }
}
