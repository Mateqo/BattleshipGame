using BattleshipGame.Models;
using BattleshipGame.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BattleshipGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GameController> _logger;

        public static Player You { get; set; }
        public static Player Bot { get; set; }

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult GameInit()
        {
            return View("Battleship");
        }

        [HttpGet]
        public IActionResult GenerateBoards(bool isRestart)
        {
            try
            {
                You = new Player() { PlayerId = 1 };
                Bot = new Player() { PlayerId = 2 };

                _gameService.GeneratePositionForShips(You,Bot);
                _gameService.GeneratePositionForShips(Bot, You);

                return Json(new { Success = true, YourShips = You.Ships, BotShips = Bot.Ships });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while generating position for you: {e}");
                return Json(new { Success = false });
            }
        }

        [HttpGet]
        public IActionResult Shoot(string player)
        {
            try
            {
                var playerWithTurn = player == "You" ? You : Bot;
                var enemy = player == "You" ? Bot : You;
                var generateResult = _gameService.GenerateRandomShoot(playerWithTurn, enemy);
                var shotResult = _gameService.Shoot(generateResult.Horizontal, generateResult.Vertical, enemy, playerWithTurn);
                return Json(new { Success = true, ShootResult = shotResult });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while shooting: {e}");
                return Json(new { Success = false });
            }
        }
    }
}
