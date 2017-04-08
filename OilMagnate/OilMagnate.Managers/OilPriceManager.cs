using System;
using OilMagnate.Models.Enums;

namespace OilMagnate.Managers
{
    public class OilPriceManager
    {
        private readonly Random _random;
        private readonly int _pricingTrendsCount;
        private readonly Tuple<int, int> _trendDurationBounds;
        private readonly Tuple<int, int> _positiveTrendChangeBounds;
        private readonly Tuple<int, int> _negativeTrendChangeBounds;
        private readonly Tuple<int, int> _stableTrendChangeBounds;
        private PricingTrends _pricingTrend;
        private int _trendDuration;

        public OilPriceManager()
        {
            OilPrice = 100;
            _random = new Random();
            _pricingTrend = PricingTrends.Positive;
            _trendDuration = 5;
            _pricingTrendsCount = Enum.GetNames(typeof(PricingTrends)).Length;
            _trendDurationBounds = new Tuple<int, int>(2, 20);
            _positiveTrendChangeBounds = new Tuple<int, int>(5, 25);
            _negativeTrendChangeBounds = new Tuple<int, int>(-25, -5);
            _stableTrendChangeBounds = new Tuple<int, int>(-10, 10);
        }

        public int OilPrice { get; private set; }

        public void ChangeOilPrice()
        {
            if (_trendDuration == 0)
            {
                ChangeTrend();
                SetTrendDuration();
            }

            _trendDuration--;
            switch (_pricingTrend)
            {
                case PricingTrends.Positive:
                    {
                        SetOilPrice(_positiveTrendChangeBounds);
                        break;
                    }
                case PricingTrends.Negative:
                    {
                        SetOilPrice(_negativeTrendChangeBounds);
                        break;
                    }
                case PricingTrends.Stable:
                    {
                        SetOilPrice(_stableTrendChangeBounds);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void ChangeTrend()
        {
            var currentTrend = (int)_pricingTrend;
            var nextTrend = currentTrend;
            var isNextSimilarToCurrent = (currentTrend == nextTrend);
            while (isNextSimilarToCurrent)
            {
                nextTrend = _random.Next(0, _pricingTrendsCount - 1);
                isNextSimilarToCurrent = (currentTrend == nextTrend);
            }

            _pricingTrend = (PricingTrends)nextTrend;
        }

        private void SetTrendDuration()
        {
            _trendDuration = _random.Next(_trendDurationBounds.Item1,
                _trendDurationBounds.Item2);
        }

        private void SetOilPrice(Tuple<int, int> changeBounds)
        {
            var changePriceCoef = 1d;
            var changePricePercentage = _random.Next(changeBounds.Item1, changeBounds.Item2);
            changePriceCoef += (double)changePricePercentage / 100;
            OilPrice = (int)((double)OilPrice * changePriceCoef);
        }
    }
}
