using Microsoft.ML.Data;

public class SentimentData
{
    [LoadColumn(0)]
    public string? Comment { get; set; }
    
    [LoadColumn(1)]
    public bool Sentiment { get; set; }
}

public class SentimentPrediction
{
    [ColumnName("PredictedLabel")]
    public bool Sentiment { get; set; }
    
    public float Score { get; set; }
}

public class SentimentRequest
{
    public string? Comment { get; set; }
}