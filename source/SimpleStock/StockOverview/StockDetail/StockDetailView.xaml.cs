﻿// ------------------------------------------------------------------------------
// <copyright file="StockDetailView.xaml.cs" company="bbv Software Services AG">
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
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for StockDetailView.xaml
    /// </summary>
    public partial class StockDetailView : UserControl
    {
        public StockDetailView()
        {
            this.InitializeComponent();
            this.DataContext = new StockDetailViewModel();
        }

        public static object SampleData
        {
            get
            {
                return new StockDetailViewModel
                {
                    StockDetail = new StockDetailModel
                    {
                        Chart = StockCharts.CH0010570759,
                        DailyChange = 0.56m,
                        DailyHigh = 33150m,
                        DailyLow = 32880m,
                        DailyVolume = 99m,
                        Id = "CH0010570759",
                        LastTrade = 33150m,
                        Name = "Chocoladefabriken Lindt & Sprüngli AG",
                        NextGeneralMeeting = new DateTime(2012, 4, 26),
                        ValorSymbol = "LISN",
                        WebSite = "http://www.lindt.com"
                    }
                };
            }
        }
    }
}
