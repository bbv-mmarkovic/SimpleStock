// ------------------------------------------------------------------------------
// <copyright file="StockDetailModel.cs" company="bbv Software Services AG">
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

namespace SimpleStock.StockOverview.StockDetail
{
    using System;
    using System.Drawing;

    public class StockDetailModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ValorSymbol { get; set; }

        public string WebSite { get; set; }

        public DateTime NextGeneralMeeting { get; set; }

        public decimal LastTrade { get; set; }

        public decimal DailyChange { get; set; }

        public decimal DailyVolume { get; set; }

        public decimal DailyLow { get; set; }

        public decimal DailyHigh { get; set; }

        public Image Chart { get; set; }
    }
}