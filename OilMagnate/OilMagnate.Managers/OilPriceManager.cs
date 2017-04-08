using System;
using OilMagnate.Models.Enums;

namespace OilMagnate.Managers
{
    public class OilPriceManager
    {
        private readonly Random _random;
        private readonly int _pricingTrendsCount; //Кількість усіх трендів
        private readonly Tuple<int, int> _trendDurationBounds; //Тривалість тренду
        private readonly Tuple<int, int> _positiveTrendChangeBounds; //Відсотковий приріст при позитивній ціні мін макс
        private readonly Tuple<int, int> _negativeTrendChangeBounds; //Відсотковий приріст при негативній ціні мін макс
        private readonly Tuple<int, int> _stableTrendChangeBounds; //Відсотковий приріст при нейтральній ціні мін макс
        private PricingTrends _pricingTrend; //Поточний тренд
        private int _trendDuration; //Довжина тренду

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

        public int OilPrice { get; private set; } //Ціна на нафту

        public void ChangeOilPrice() //Викликається щокроку
        {
            if (_trendDuration == 0) //Якщо заінчився тренд, то перевизначити тренд
            {
                ChangeTrend();
                SetTrendDuration(); //Задати тривалість новому тренду
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

        private void ChangeTrend() //Зміна тренду
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

        private void SetTrendDuration() //Задати довжину тренду
        {
            _trendDuration = _random.Next(_trendDurationBounds.Item1,
                _trendDurationBounds.Item2);
        }

        private void SetOilPrice(Tuple<int, int> changeBounds) //Задати ціну на нафту
        {
            var changePriceCoef = 1d;
            var changePricePercentage = _random.Next(changeBounds.Item1, changeBounds.Item2);
            changePriceCoef += (double)changePricePercentage / 100;
            OilPrice = (int)((double)OilPrice * changePriceCoef);
        }
    }
}
