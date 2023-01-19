using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ_Example.Models;
using RabbitMQ_Example.RabbitMQ;

namespace RabbitMQ_Example.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRabbitMQProducer _rabbitMQ;

    public HomeController(ILogger<HomeController> logger, IRabbitMQProducer rabbitMQ)
    {
        _logger = logger;
        _rabbitMQ = rabbitMQ;
    }

    public IActionResult Index()
    {
        _rabbitMQ.SendMessage<string>("Hello Word");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
