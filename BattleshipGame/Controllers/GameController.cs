using BattleshipGame.Models;
using BattleshipGame.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BattleshipGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GameController> _logger;

        public Player You { get; set; }
        public Player Bot { get; set; }

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;

            You = new Player() { PlayerId = 1 };
            Bot = new Player() { PlayerId = 2 };
        }

        [HttpGet]
        public IActionResult GameInit()
        {
            return View("Battleship");
        }

        [HttpGet]
        public IActionResult GenerateBoards()
        {
            try
            {
                _gameService.GeneratePositionForShips(You);
                _gameService.GeneratePositionForShips(Bot);

                return Json(new { Success = true, YourShips = You.Ships, BotShips = Bot.Ships });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while generate position for you: {e}");
                return Json(new { Success = false });
            }
        }
    }
}
