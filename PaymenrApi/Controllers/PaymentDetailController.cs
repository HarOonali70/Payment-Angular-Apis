using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymenrApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymenrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context) { 
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails() 
        {
            try {
                return await _context.PaymentDetails.ToListAsync();
            }
            catch (Exception ex) { 
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> PostPaymentDetails(PaymentDetails paymentDetails) 
        {
            _context.PaymentDetails.Add(paymentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.PaymentDetailId }, paymentDetails);
        }
        [HttpPut]
        public async Task<ActionResult> PutPaymentDetails(int id,PaymentDetails paymentDetails) 
        {
            if (id != paymentDetails.PaymentDetailId) 
            {
                    return BadRequest();
            }
            try {
                _context.PaymentDetails.Update(paymentDetails).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.PaymentDetailId }, paymentDetails);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePaymentDetails(int id) 
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail != null)
            {
                _context.PaymentDetails.Remove(paymentDetail);
                _context.SaveChangesAsync();
                return NoContent();
            }
            else {
                return BadRequest();
            }
        }
    } 
}
