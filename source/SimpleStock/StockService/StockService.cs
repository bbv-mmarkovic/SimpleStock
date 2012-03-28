// ------------------------------------------------------------------------------
// <copyright file="StockService.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SimpleStock.StockService
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Linq;

    using SimpleStock.StockOverview;

    public class StockService : IStockService
    {
        private static readonly StockDetailCollection StockDetailMap = new StockDetailCollection
        {
            CreateStockDetail("CH0012221716", "ABB Ltd", "ABBN", "http://www.abb.ch", new DateTime(2012, 4, 26), 18.51m, -0.32m, 3405392m, 18.46m, 18.79m, StockCharts.CH0012221716),
            CreateStockDetail("CH0010570759", "Chocoladefabriken Lindt & Sprüngli AG", "LISN", "http://www.lindt.com", new DateTime(2012, 4, 26), 33150m, 0.56m, 99m, 32880m, 33150m, StockCharts.CH0010570759),
            CreateStockDetail("CH0012138530", "Credit Suisse Group AG", "CSGN", "http://www.credit-suisse.com", new DateTime(2012, 4, 27), 26.38m, -0.53m, 6376267m, 26.33m, 27.17m, StockCharts.CH0012138530),
            CreateStockDetail("CH0030486770", "Dätwyler Holding AG", "DAE", "http://www.datwyler.com", new DateTime(2012, 4, 24), 74.90m, -0.07m, 3944m, 73.55m, 75.60m, StockCharts.CH0030486770),
            CreateStockDetail("CH0012829898", "Emmi AG", "EMMN", "http://www.emmi.ch", new DateTime(2012, 5, 3), 198.20m, -0.90m, 385m, 198.00m, 200.00m, StockCharts.CH0012829898),
            CreateStockDetail("CH0012255151", "The Swatch Group AG", "UHR", "http://www.swatchgroup.com", new DateTime(2012, 5, 16), 425.90m, -0.02m, 102306m, 425.30m, 432.20m, StockCharts.CH0012255151),
            CreateStockDetail("CH0024899483", "UBS AG", "UBSN", "http://www.ubs.com", new DateTime(2012, 5, 3), 13.02m, 0.15m, 8542964m, 12.99m, 13.20m, StockCharts.CH0024899483),
        };

        public IList<StockEntry> GetStockList()
        {
            return StockDetailMap.Select(stock => new StockEntry(stock.Id, stock.Name)).ToList();
        }

        public StockDetailInfo GetStockDetail(string id)
        {
            return StockDetailMap.Contains(id) ? StockDetailMap[id] : new StockDetailInfo(id, "Unknown") { ValorSymbol = "???" };
        }

        private static StockDetailInfo CreateStockDetail(
            string id,
            string name,
            string valorSymbol,
            string webSite,
            DateTime nextGeneralMeeting,
            decimal lastTrade,
            decimal dailyChange,
            decimal dailyVolume,
            decimal dailyLow,
            decimal dailyHigh,
            Image chart)
        {
            return new StockDetailInfo(id, name)
            {
                ValorSymbol = valorSymbol,
                WebSite = webSite,
                NextGeneralMeeting = nextGeneralMeeting,
                LastTrade = lastTrade,
                DailyChange = dailyChange,
                DailyVolume = dailyVolume,
                DailyLow = dailyLow,
                DailyHigh = dailyHigh,
                Chart = chart
            };
        }

        public class StockDetailCollection : KeyedCollection<string, StockDetailInfo>
        {
            protected override string GetKeyForItem(StockDetailInfo item)
            {
                return item.Id;
            }
        }
    }
}