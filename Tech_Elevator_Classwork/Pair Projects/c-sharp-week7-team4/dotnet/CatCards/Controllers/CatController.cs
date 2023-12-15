using System.Collections.Generic;
using System.Diagnostics;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("/api/cards/")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatCardDao cardDao;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CatController(ICatCardDao _cardDao, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDao = _cardDao;
        }

        [HttpGet()]
        public List<CatCard> GetAllCards()
        {
            return cardDao.GetAllCards();
        }

        [HttpGet("random")]
        public CatCard GetRandomCard()
        {
            CatCard newCard = new CatCard();
            CatFact newFact = catFactService.GetFact();
            CatPic newPic = catPicService.GetPic();
            newCard.CatFact = newFact.Text;
            newCard.ImgUrl = newPic.File;
            return newCard;
        }



        [HttpGet("{id}")]
        public ActionResult<CatCard> GetCard(int id)
        {
            CatCard card = cardDao.GetCard(id);
            if (card != null)
            {
                return Ok(card);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        public ActionResult<CatCard> CreateCard(CatCard catCard)
        {
            CatCard newCatCard = cardDao.SaveCard(catCard);
            return Created($"/api/cards/{newCatCard.CatCardId}", newCatCard);
        }

        [HttpPut("{id}")]
        public ActionResult<CatCard> UpdateCard(CatCard catCard, int id)
        {
            catCard.CatCardId = id;
            if (cardDao.UpdateCard(catCard))
            {
                return Ok(catCard);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCard(int id)
        {
            bool didWork = cardDao.RemoveCard(id);
            if (didWork)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
