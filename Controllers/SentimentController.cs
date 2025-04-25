using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SentimentController : ControllerBase
{
    private readonly SentimentService _sentimentService;
    
    public SentimentController(SentimentService sentimentService)
    {
        _sentimentService = sentimentService;
    }
    
    [HttpGet("predict")]
    public IActionResult Predict([FromQuery] string comment)
    {
        if (string.IsNullOrWhiteSpace(comment))
            return BadRequest("El comentario no puede estar vacío.");
        
        var result = _sentimentService.PredictSentiment(comment);
        return Ok(new { Sentiment = result ? "Positivo" : "Negativo" });
    }
    
    [HttpPost("analyze")]
    public IActionResult Analyze([FromBody] SentimentRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Comment))
            return BadRequest(new { error = "El comentario no puede estar vacío." });
        
        var isPositive = _sentimentService.PredictSentiment(request.Comment);
        return Ok(new
        {
            Sentiment = isPositive ? "Positivo" : "Negativo"
        });
    }
}