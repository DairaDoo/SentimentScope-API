# 🎭 SentimentScope

**SentimentScope** es una API de análisis de sentimientos que determina si un texto expresa un sentimiento positivo o negativo. Utilizando técnicas de Machine Learning, esta herramienta clasifica automáticamente comentarios, reviews y otros textos en español.

<p align="center">
  <img src="/img/sentiment_scope_logo.png" alt="SentimentScope Banner" width="600"/>
</p>


## 📊 ¿Qué hace?

SentimentScope analiza el texto que envías y te dice si expresa un sentimiento:
- ✅ **Positivo**: "Me encantó el producto, funciona perfectamente"
- ❌ **Negativo**: "El servicio fue terrible, no lo recomendaría"

## 🧠 Tecnologías utilizadas

- **ASP.NET Core**: Framework para construir APIs web modernas
- **ML.NET**: Biblioteca de Microsoft para Machine Learning en .NET
- **Algoritmo**: Regresión Logística (SDCA) para clasificación binaria
- **Técnicas NLP**: Vectorización de texto y análisis de características lingüísticas

## 🚀 Endpoints API

La API ofrece dos endpoints principales:

### GET /api/Sentiment/predict

```
GET /api/Sentiment/predict?comment=Este producto es fantástico
```

### POST /api/Sentiment/analyze

```json
POST /api/Sentiment/analyze
Content-Type: application/json

{
  "comment": "La atención al cliente fue pésima, esperé más de una hora"
}
```

Ambos endpoints devuelven:

```json
{
  "sentiment": "Positivo" // o "Negativo"
}
```

## 📋 Requisitos

- .NET 7.0 o superior
- Archivo CSV de entrenamiento con formato: `Comment,Sentiment`

## 🛠️ Instalación

1. Clona este repositorio
```bash
git clone https://github.com/[tu-usuario]/SentimentScope.git
```

2. Navega al directorio del proyecto
```bash
cd SentimentScope
```

3. Restaura las dependencias
```bash
dotnet restore
```

4. Compila el proyecto
```bash
dotnet build
```

5. Ejecuta la aplicación
```bash
dotnet run
```

6. Accede a Swagger UI para probar la API
```
http://localhost:5268/swagger
```

## 📈 ¿Cómo funciona?

1. **Entrenamiento**: El sistema carga datos etiquetados desde un CSV
2. **Procesamiento**: Convierte el texto en vectores numéricos
3. **Aprendizaje**: El algoritmo identifica patrones asociados a sentimientos
4. **Predicción**: Ante nuevos textos, clasifica su sentimiento

## 🧪 Conjunto de datos

El modelo se entrena con una colección de comentarios etiquetados como positivos (`true`) o negativos (`false`).

```csv
Comment,Sentiment
Me encantó este producto,true
El servicio fue terrible,false
...
```

## 👨‍💻 Sobre mí

Soy un desarrollador que está comenzando a explorar el fascinante mundo de la AI, justo estoy tomando el curso de AI practitioner y quería hacer una implementación práctica con algo simple. Este proyecto representa mi primer acercamiento práctico a la implementación de técnicas de ML en aplicaciones reales. Elegí .NET Core como plataforma debido a su robustez y la integración nativa con ML.NET, lo que me permite crear soluciones de IA sin necesidad de cambiar de ecosistema de desarrollo.

## 📚 Recursos de aprendizaje

- [Documentación oficial de ML.NET](https://learn.microsoft.com/en-us/dotnet/machine-learning/)
- [Tutoriales de análisis de sentimientos](https://learn.microsoft.com/en-us/dotnet/machine-learning/tutorials/sentiment-analysis)

## 📄 Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.
