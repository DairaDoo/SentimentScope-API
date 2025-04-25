using Microsoft.ML;
using System.IO;
using Microsoft.ML.Data;

public class SentimentService
{
    private readonly MLContext _mlContext;
    private readonly ITransformer _model;
    
    public SentimentService(IWebHostEnvironment environment)
    {
        _mlContext = new MLContext();
        
        // Ruta absoluta al archivo CSV
        string dataPath = Path.Combine(environment.ContentRootPath, "Data", "sentiment.csv");
        
        // Verificar si el archivo existe
        if (!File.Exists(dataPath))
        {
            throw new FileNotFoundException($"El archivo de datos no fue encontrado en la ruta: {dataPath}");
        }
        
        // 1) Carga datos
        var data = _mlContext.Data.LoadFromTextFile<SentimentData>(
            dataPath, 
            hasHeader: true, 
            separatorChar: ',');
        
        // 2) Define el pipeline:
        var pipeline = _mlContext.Transforms.Text
            .FeaturizeText(
                outputColumnName: "Features",
                inputColumnName: nameof(SentimentData.Comment))
            // 3) Copia tu propiedad 'Sentiment' a la columna 'Label'
            .Append(_mlContext.Transforms.CopyColumns(
                outputColumnName: "Label",
                inputColumnName: nameof(SentimentData.Sentiment)))
            // 4) Entrena usando 'Label' y 'Features'
            .Append(_mlContext.BinaryClassification
                .Trainers.SdcaLogisticRegression(
                    labelColumnName: "Label",
                    featureColumnName: "Features"));
        
        // 5) Ajusta el modelo
        _model = pipeline.Fit(data);
    }
    
    public bool PredictSentiment(string comment)
    {
        var predictionEngine = _mlContext.Model
            .CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);
        
        var prediction = predictionEngine.Predict(
            new SentimentData { Comment = comment });
        
        return prediction.Sentiment;
    }
}