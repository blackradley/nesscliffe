namespace DataAccess.Predictions
{
    interface IPrediction
    {
        double Predicted { get; }
        double PredictedUpper { get; }
    }
}
